using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoorExercise
{
    public class DoorControl
    {
       private IDoor _door;
       private IUserValidation _uv;
       private IEntryNotification _en;
       private IAlarm _alarm;
       private Doorstate state;

       private enum Doorstate
       {
          Closed,
          Opening,
          Closing
       }
       public DoorControl(IDoor door, IUserValidation uv, IEntryNotification en, IAlarm alarm)
       {
          _door = door;
          _uv = uv;
          _en = en;
          _alarm = alarm;

          state = Doorstate.Closed;
       }


       public void RequestEntry(int id)
       {
          if (_uv.ValidateEntryRequest(id) == true)
          {
             _door.Open();
             _en.NotifyEntryGranted();
             state = Doorstate.Opening;
          }
       }

       public void DoorOpened()
       {
          if (_door.Open() == true)
          {
             _door.Close();
             state = Doorstate.Closing;
          }
       }

       public void DoorClosed()
       {
          if (_door.Close() == true)
          {
             state = Doorstate.Closed;
          }
       }
       
    }
}
