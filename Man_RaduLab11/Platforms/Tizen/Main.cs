﻿using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Man_RaduLab11;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}

