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
using Balder.Core.Display;
using Balder.Core.Math;
using Balder.Core.Objects.Geometries;
using Ninject.Core;

namespace Balder.Core.Debug
{
	public class DebugShape : RenderableNode
	{
		[Inject]
		public IGeometryContext GeometryContext { get; set; }


		public virtual void Initialize()
		{
			
		}

		public override void Render(Viewport viewport, Matrix view, Matrix projection)
		{
			GeometryContext.Render(viewport, this, view, projection, World);
		}
	}
}
