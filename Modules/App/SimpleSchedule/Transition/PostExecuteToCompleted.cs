﻿using System;
using Common.StateMach;
using VixenModules.App.SimpleSchedule.Service;

namespace VixenModules.App.SimpleSchedule.Transition {
	class PostExecuteToCompleted : ITransition<IScheduledItemStateObject> {
		public Predicate<IScheduledItemStateObject> Condition {
			get { return _TransitionCondition; }
		}

		public IState<IScheduledItemStateObject> TargetState {
			get { return States.CompletedState; }
		}

		private bool _TransitionCondition(IScheduledItemStateObject item) {
			return !ScheduledItemService.Instance.ScheduledItemQualifiesForExecution(item);
		}
	}
}
