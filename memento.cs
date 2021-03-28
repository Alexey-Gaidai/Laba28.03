﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Laba28._03
{
    public class Memento
    {
        public string State { get; private set; }
        public Memento(string state)
        {
            this.State = state;
        }
    }
    public class Caretaker
    {
        public Memento Memento { get; set; }
    }
    public class Originator
    {
        public string State { get; set; }
        public void SetMemento(Memento memento)
        {
            State = memento.State;
        }
        public Memento CreateMemento()
        {
            return new Memento(State);
        }
    }
}
