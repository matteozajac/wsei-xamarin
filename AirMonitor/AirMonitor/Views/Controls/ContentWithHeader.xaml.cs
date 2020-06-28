using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AirMonitor.Views.Controls
{
    public partial class ContentWithHeader : StackLayout
    {
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(
            propertyName: nameof(Title),
            returnType: typeof(string),
            declaringType: typeof(ContentWithHeader),
            defaultValue: null);

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly BindableProperty ControlContentProperty = BindableProperty.Create(
            propertyName: nameof(ControlContent),
            returnType: typeof(View),
            declaringType: typeof(ContentWithHeader),
            defaultValue: null);

        public View ControlContent
        {
            get { return (View)GetValue(ControlContentProperty); }
            set { SetValue(ControlContentProperty, value); }
        }

        public ContentWithHeader()
        {
            InitializeComponent();
        }
    }
}
