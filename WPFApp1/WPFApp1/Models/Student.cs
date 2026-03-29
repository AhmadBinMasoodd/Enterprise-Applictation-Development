using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WPFApp1.Models;

public partial class Student :INotifyPropertyChanged
{
    public int Id { get; set; }

    private string? sname;
    private int? sage;

    public string? Sname
    {
        get
        {
           return this.sname;
        }
        set
        {
            sname = value;
            OnPropertyChanged(nameof(Sname));
        } 
    }

    public int? Sage
    {
        get
        {
            return sage;
        }
        set
        {
            sage = value;
            OnPropertyChanged(nameof(Sage));
        } 
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
