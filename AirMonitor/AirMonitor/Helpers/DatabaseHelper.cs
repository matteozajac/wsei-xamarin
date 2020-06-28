using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AirMonitor.Models;
using AirMonitor.Models.Tables;
using Newtonsoft.Json;
using SQLite;

namespace AirMonitor.Helpers
{
    public class DatabaseHelper : IDisposable
    {
        private SQLiteConnection _connection;

        public void Initialize()
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "data.db");

            _connection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);

            _connection.CreateTable<InstallationEntity>();
            _connection.CreateTable<MeasurementEntity>();
            _connection.CreateTable<MeasurementItemEntity>();
            _connection.CreateTable<MeasurementValue>();
            _connection.CreateTable<AirQualityIndex>();
            _connection.CreateTable<AirQualityStandard>();
        }

        public void SaveInstallations(IEnumerable<Installation> installations)
        {
            var entries = installations.Select(s => new InstallationEntity(s));

            _connection?.RunInTransaction(() =>
            {
                _connection?.DeleteAll<InstallationEntity>();
                _connection?.InsertAll(entries);
            });
        }

        public IEnumerable<Installation> GetInstallations()
        {
            return _connection?.Table<InstallationEntity>().Select(s => new Installation(s)).ToList();
        }

        public void SaveMeasurements(IEnumerable<Measurement> measurements)
        {
            _connection?.RunInTransaction(() =>
            {
                _connection?.DeleteAll<MeasurementValue>();
                _connection?.DeleteAll<AirQualityIndex>();
                _connection?.DeleteAll<AirQualityStandard>();
                _connection?.DeleteAll<MeasurementItemEntity>();
                _connection?.DeleteAll<MeasurementEntity>();


                foreach(var measurement in measurements)
                {
                    _connection?.InsertAll(measurement.Current.Values, false);
                    _connection?.InsertAll(measurement.Current.Indexes, false);
                    _connection?.InsertAll(measurement.Current.Standards, false);

                    var measurementItemEntity = new MeasurementItemEntity(measurement.Current);
                    _connection?.Insert(measurementItemEntity);

                    var measurementEntity = new MeasurementEntity(measurementItemEntity.Id, measurement.Installation.Id);
                    _connection?.Insert(measurementEntity);
                }
            });
        }

        public IEnumerable<Measurement> GetMeasurements()
        {
            return _connection?.Table<MeasurementEntity>().Select(s =>
            {
                var measurementItem = GetMeasurementItem(s.CurrentMeasurementItemId);
                var installation = GetInstallation(s.InstallationId);
                return new Measurement(measurementItem, installation);
            }).ToList();
        }

        private MeasurementItem GetMeasurementItem(int id)
        {
            var entity = _connection?.Get<MeasurementItemEntity>(id);
            var valueIds = JsonConvert.DeserializeObject<int[]>(entity.MeasurementValueIds);
            var indexIds = JsonConvert.DeserializeObject<int[]>(entity.AirQualityIndexIds);
            var standardIds = JsonConvert.DeserializeObject<int[]>(entity.AirQualityStandardIds);
            var values = _connection?.Table<MeasurementValue>().Where(s => valueIds.Contains(s.Id)).ToArray();
            var indexes = _connection?.Table<AirQualityIndex>().Where(s => indexIds.Contains(s.Id)).ToArray();
            var standards = _connection?.Table<AirQualityStandard>().Where(s => standardIds.Contains(s.Id)).ToArray();
            return new MeasurementItem(entity, values, indexes, standards);
        }

        private Installation GetInstallation(string id)
        {
            var entity = _connection?.Get<InstallationEntity>(id);
            return new Installation(entity);
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _connection?.Dispose();
                    _connection = null;
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
        }
        #endregion
    }
}
