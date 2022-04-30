﻿// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/iBowie/mvvmgen
// Based on MvvmGen by by Thomas Claudius Huber (https://github.com/thomasclaudiushuber/mvvmgen)
// Copyright © by Thomas Claudius Huber (Adapted to MvvmLight by BowieD)
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

using System.Collections.Generic;

namespace MvvmLightGen.Events
{
    public class TestEventSubscriber<T> : IEventSubscriber<T>
    {
        public List<T> ReceivedEvents { get; private set; } = new();

        public void OnEvent(T theEvent)
        {
            ReceivedEvents.Add(theEvent);
        }
    }

    public class TestAllEventsSubscriberSeparateInterfaces : IEventSubscriber<CustomerDeletedEvent>, IEventSubscriber<CustomerAddedEvent>
    {
        public CustomerDeletedEvent? ReceivedCustomerDeletedEvent { get; private set; }
        public CustomerAddedEvent? ReceivedCustomerAddedEvent { get; private set; }

        public void OnEvent(CustomerDeletedEvent theEvent)
        {
            ReceivedCustomerDeletedEvent = theEvent;
        }

        public void OnEvent(CustomerAddedEvent theEvent)
        {
            ReceivedCustomerAddedEvent = theEvent;
        }
    }

    public class CustomerAllEventsSubscriberSingleInterface : IEventSubscriber<CustomerDeletedEvent, CustomerAddedEvent>
    {
        public CustomerDeletedEvent? ReceivedCustomerDeletedEvent { get; private set; }
        public CustomerAddedEvent? ReceivedCustomerAddedEvent { get; private set; }

        public void OnEvent(CustomerDeletedEvent theEvent)
        {
            ReceivedCustomerDeletedEvent = theEvent;
        }

        public void OnEvent(CustomerAddedEvent theEvent)
        {
            ReceivedCustomerAddedEvent = theEvent;
        }
    }
}
