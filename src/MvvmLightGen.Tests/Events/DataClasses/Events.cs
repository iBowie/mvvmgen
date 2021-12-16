// ***********************************************************************
// ⚡ MvvmLightGen => https://github.com/thomasclaudiushuber/mvvmgen
// Copyright © by Thomas Claudius Huber
// Licensed under the MIT license => See LICENSE file in repository root
// ***********************************************************************

namespace MvvmLightGen.Events
{
    public record CustomerAddedEvent(int CustomerId);
    public record CustomerDeletedEvent(int CustomerId);
}
