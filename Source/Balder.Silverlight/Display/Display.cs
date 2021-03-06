﻿#region License
//
// Author: Einar Ingebrigtsen <einar@dolittle.com>
// Copyright (c) 2007-2009, DoLittle Studios
//
// Licensed under the Microsoft Permissive License (Ms-PL), Version 1.1 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the license at 
//
//   http://balder.codeplex.com/license
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
#endregion
using System.ComponentModel;
using System.Windows.Media.Imaging;
using Balder.Core;
using Balder.Core.Display;
using Balder.Core.Execution;
using Balder.Core.SoftwareRendering;
using Balder.Silverlight.SoftwareRendering;

namespace Balder.Silverlight.Display
{
	public class Display : IDisplay, INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged = (s, e) => { };

		private readonly IPlatform _platform;
		private IBuffers _buffers;
		private bool _initialized;

		public Display(IPlatform platform)
		{
			_platform = platform;
		}

		public void Initialize(int width, int height)
		{
			_buffers = BufferManager.Instance.Create<FrameBuffer>(width, height);
			FramebufferBitmap = new WriteableBitmap(width, height);
			_initialized = true;
			BackgroundColor = Color.FromArgb(0xff, 0, 0, 0);
		}

		public Color BackgroundColor { get; set; }
		public WriteableBitmap FramebufferBitmap { get; private set; }

		public void PrepareRender()
		{
			BufferManager.Instance.Current = _buffers;
		}
		

		public void Swap()
		{
			if (_initialized)
			{
				_buffers.Swap();
			}
		}

		public void Clear()
		{
			if (_initialized)
			{
				_buffers.Clear();
			}
		}

		public void Show()
		{
			if (_initialized)
			{
				_buffers.Show();
				_buffers.FrameBuffer.BackBuffer.CopyTo(FramebufferBitmap.Pixels, 0);
			}
		}

		public void Update()
		{
			if( _initialized)
			{
				FramebufferBitmap.Invalidate();
			}
		}
	}
}