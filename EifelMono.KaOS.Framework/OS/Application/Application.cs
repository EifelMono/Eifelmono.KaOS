﻿using EifelMono.KaOS;
using EifelMono.KaOS.Implementation;

[assembly: BackDoor(typeof(EifelMono.KaOS.Framework.Application))]
namespace EifelMono.KaOS.Framework
{
    public class Application : ApplicationCore
    {
        public override bool IsAvailable { get => false; }
    }
}