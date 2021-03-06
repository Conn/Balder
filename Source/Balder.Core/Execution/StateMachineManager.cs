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
using System.Collections.Generic;

namespace Balder.Core.Execution
{
	public class StateMachineManager
	{
		public static readonly StateMachineManager Instance = new StateMachineManager();

		private List<IStateMachine> _stateMachines;

		private StateMachineManager()
		{
			_stateMachines = new List<IStateMachine>();
		}

		public void Register(IStateMachine stateMachine)
		{
			_stateMachines.Add(stateMachine);
		}

		public void Unreqister(IStateMachine stateMachine)
		{
			_stateMachines.Remove(stateMachine);
		}


		internal void Run()
		{
			foreach (IStateMachine stateMachine in _stateMachines)
			{
				stateMachine.Execute();
			}
		}
	}
}