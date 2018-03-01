using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NSubstitute;
using NUnit.Framework;

namespace DoorExercise.Test.Unit
{
   [TestFixture]
    public class DoorExerciseUnitTest
   {
      private IDoor door;
      private IUserValidation uv;
      private IAlarm alarm;
      private IEntryNotification en;
      private DoorControl uut;

      [SetUp]
      public void SetUp()
      {
         door = Substitute.For<IDoor>();
         uv = Substitute.For<IUserValidation>();
         alarm = Substitute.For<IAlarm>();
         en = Substitute.For<IEntryNotification>();

         uut = new DoorControl(door,uv,en,alarm);
      }

      [Test]
      public void Const_state_closed()
      {
        
      }
    }
}
