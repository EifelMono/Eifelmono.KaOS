﻿using System;
namespace EifelMono.KaOS.Implementation.OSx
{
    public class Dialogs : IDialogs
    {
        public bool IsAvailable => throw new NotImplementedException();

        public string OpenFileDialog(string path, string[] extensions = null)
        {
            throw new NotImplementedException();
        }
    }
}