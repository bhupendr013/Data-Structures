using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterDemo
{
    public interface IElevator
    {
        int GetCurrentFloor();
        void MoveUp();
        void MoveDown();

        int NextDestination();

        void RemoveDestination();

        void AddDestination(int floor);

        ElevatorDirection GetDirection();

        ElevatorStatus GetStatus();
    }

    public interface IElevatorControl
    {

    }

    public enum ElevatorStatus
    {
        Elevtor_Occupied,
        Elevtor_Empty
    }

    public enum ElevatorDirection
    {
        ELEVATOR_UP,
        ELEVATOR_DOWN,
        ELEVATOR_HOLD
    }
    public class ELevatorContol : IElevatorControl
    {
        public const int MAX_ELEVATORS = 16;

        private int elevatorCount;
        private int floorCount;
        private Queue<int> elevatorRequests;
        private ArrayList elevators;
        public ELevatorContol(int eleCount, int flCount)
        {
            elevatorCount = (eleCount > MAX_ELEVATORS ? MAX_ELEVATORS : eleCount);
            floorCount = flCount;
            elevatorRequests = new Queue<int>();
            elevators = new ArrayList();
            for (int i = 0; i < elevatorCount; i++)
            {
                elevators.Add(new Elevator(i));
            }
        }

        public ArrayList GetElevator()
        {
            return elevators;
        }

        public void AddPickUp(int floor)
        {
            elevatorRequests.Enqueue(floor);
        }

        public void AddDestination(int elevatorId, int floor)
        {
            //elevators.
            //elevators.Get(elevatorId).Add(floor);

        }

        public void Step()
        {
            foreach(var elevator in elevators)
            {
                //switch(elevator.GetStatus)
            }
        }

    }
    public class Elevator : IElevator
    {
        private Queue<int> destFloors;
        private int currentFloor;
        public Elevator(int florno)
        {
            this.destFloors = new Queue<int>();
            this.currentFloor = florno;
        }

        public void MoveUp()
        {
            currentFloor++;
        }

        public void MoveDown()
        {
            currentFloor--;
        }

        public int GetCurrentFloor()
        {
            return currentFloor;
        }

        public int NextDestination()
        {
            return destFloors.Peek();
        }

        public void RemoveDestination()
        {
            destFloors.Dequeue();
        }

        public void AddDestination(int floor)
        {
            destFloors.Enqueue(floor);
        }

        public ElevatorDirection GetDirection()
        {
            if (destFloors.Count() > 0)
            {
                if (currentFloor > destFloors.Peek())
                {
                    return ElevatorDirection.ELEVATOR_DOWN;
                }
                else if (currentFloor < destFloors.Peek())
                {
                    return ElevatorDirection.ELEVATOR_UP;
                }
            }
            return ElevatorDirection.ELEVATOR_HOLD;
        }

        public ElevatorStatus GetStatus()
        {
            return destFloors.Count() > 0 ? ElevatorStatus.Elevtor_Occupied : ElevatorStatus.Elevtor_Empty;
        }
    }

}
