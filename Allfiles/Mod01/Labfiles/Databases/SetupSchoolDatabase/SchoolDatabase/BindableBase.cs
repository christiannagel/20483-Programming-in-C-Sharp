using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SchoolDatabase
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetProperty<T>(ref T item, T value, [CallerMemberName] string? propertyName = default)
        {
            if (EqualityComparer<T>.Default.Equals(item, value))
            {
                return false;
            }
            item = value;
            FirePropertyChanged(propertyName);
            return true;
        }

        protected virtual void FirePropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
