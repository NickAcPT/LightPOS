// 
// Copyright (c) NickAc. All rights reserved.
// Licensed under the MIT License. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Globalization;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace NickAc.LightPOS.Frontend.Utils
{
    public class Money : INotifyPropertyChanged
    {
        private string _stringValue;
        private decimal _value;

        public Money(string stringValue)
        {
            StringValue = stringValue;
        }

        public Money(decimal value)
        {
            Value = value;
        }

        public decimal Value
        {
            get => _value;
            set
            {
                if (value == _value) return;
                _value = value;

                _stringValue = GenerateStringValue(value);

                OnPropertyChanged();
            }
        }

        private static string GenerateStringValue(decimal value)
        {
            return value.ToString("0.00", CultureInfo.InvariantCulture);
        }

        public string StringValue
        {
            get => _stringValue;
            set
            {
                if (value == _stringValue) return;
                _stringValue = value ?? "";

                var result = decimal.TryParse((value ?? "").Replace(',', '.'), NumberStyles.Currency, CultureInfo.InvariantCulture, out var finalDecimal);
                if (result)
                    _value = finalDecimal;
                _stringValue = GenerateStringValue(_value);
                
                OnPropertyChanged();
            }
        }
        
        public static Money operator +(Money m, Money m2)
        {
            return new Money(m.Value + m2.Value);
        }

        public static Money operator -(Money m, Money m2)
        {
            return new Money(m.Value - m2.Value);
        }
        
        public static Money operator /(Money m, Money m2)
        {
            return new Money(m.Value / m2.Value);
        }

        public static Money operator *(Money m, Money m2)
        {
            return new Money(m.Value * m2.Value);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}