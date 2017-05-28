﻿using System;

namespace EifelMono.KaOS
{
    public class Checker
    {
        private bool _Flag = true;

        public bool Flag { get => _Flag; set => _Flag = value; }

        public bool IsFirst
        {
            get
            {
                if (_Flag)
                {
                    _Flag = false;
                    return true;
                }
                return false;
            }
        }

        public bool IsRegistered => !IsFirst;
    }

    public class Checker<T> : Checker where T : IComparable
    {
        public Checker()
        {
            DefaultValue = default(T);
            Reset(true);
        }

        public Checker(T defaultValue)
        {
            DefaultValue = defaultValue;
            Reset(true);
        }

        public void Reset(bool withDefaultValue)
        {
            Flag = true;
            if (withDefaultValue)
                Value = DefaultValue;
        }

        public T DefaultValue { get; private set; }

        public T Value { get; set; }

        public bool IsFirstOrEqual(T value, bool setValue = true)
        {
            bool result = false;
            if (IsFirst || Value.CompareTo(value) == 0)
                result = true;
            if (setValue)
                Value = value;
            return result;
        }

        public bool IsFirstOrNotEqual(T value, bool setValue = true)
        {
            bool result = false;
            if (IsFirst || Value.CompareTo(value) != 0)
                result = true;
            if (setValue)
                Value = value;
            return result;
        }

        public bool IsFirstOrChanged(T value, bool setValue = true)
        {
            return IsFirstOrNotEqual(value, setValue);
        }
    }
}