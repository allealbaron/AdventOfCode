using System;
using System.Collections.Generic;
using System.Text;

namespace Task12
{
    class Cruise
    {
        /// <summary>
        /// Direction
        /// </summary>
        public enum DirectionEnum
        {
            N=0,
            E=1,
            S=2,
            W=3
        }
        /// <summary>
        /// Movements
        /// </summary>
        public List<Movement> Movements;

        /// <summary>
        /// Direction
        /// </summary>
        private DirectionEnum Direction;

        /// <summary>
        /// Horizontal position
        /// </summary>
        public int HorizontalMovement;

        /// <summary>
        /// Vertical position
        /// </summary>
        public int VerticalMovement;

        /// <summary>
        /// Horizontal WayPoint
        /// </summary>
        public int HorizontalWayPoint;

        /// <summary>
        /// Vertical WayPoint
        /// </summary>
        public int VerticalWayPoint;

        /// <summary>
        /// Class builder
        /// </summary>
        public Cruise()
        {
            Movements = new List<Movement>();
            Direction = DirectionEnum.E;
            
            VerticalMovement = 0;
            HorizontalMovement = 0;
            
            HorizontalWayPoint = 10;
            VerticalWayPoint = 1;

        }

        /// <summary>
        /// Move the ship for the first part of the problem
        /// </summary>
        public void NavigateFirstPart()
        {
            foreach (Movement m in Movements)
            {
                MovePosition(m);
            }
        }

        /// <summary>
        /// Move the ship for the second part of the problem
        /// </summary>
        public void NavigateSecondPart()
        {
            foreach (Movement m in Movements)
            {
                MovePositionRelative(m);
            }
        }

        /// <summary>
        /// Move the ship using a movement
        /// </summary>
        /// <param name="movement">Movement to execute</param>
        private void MovePosition(Movement movement)
        {
            switch (movement.Move)
            {
                case Movement.MoveEnum.F:

                    switch (this.Direction)
                    {
                        case DirectionEnum.N:
                            MoveVertical(movement.Quantity);
                            break;
                        case DirectionEnum.S:
                            MoveVertical(-movement.Quantity);
                            break;
                        case DirectionEnum.E:
                            MoveHorizontal(movement.Quantity);
                            break;
                        case DirectionEnum.W:
                            MoveHorizontal(-movement.Quantity);
                            break;
                    }
                    break;

                case Movement.MoveEnum.N:
                    MoveVertical(movement.Quantity);
                    break;

                case Movement.MoveEnum.S:
                    MoveVertical(-movement.Quantity);
                    break;

                case Movement.MoveEnum.E:
                    MoveHorizontal(movement.Quantity);
                    break;

                case Movement.MoveEnum.W:
                    MoveHorizontal(-movement.Quantity);
                    break;

                case Movement.MoveEnum.R:
                    Direction = (DirectionEnum)(((int)Direction + (movement.Quantity / 90)) % 4);
                    break;

                case Movement.MoveEnum.L:
                    Direction = (DirectionEnum)(((int)Direction + ((360-movement.Quantity) / 90)) % 4);
                    break;

            }
        }

        /// <summary>
        /// Moves Vertical 
        /// </summary>
        /// <param name="quantity">number of times</param>
        private void MoveVertical(int quantity)
        {
            VerticalMovement += quantity;
        }

        /// <summary>
        /// Moves Horizontal
        /// </summary>
        /// <param name="quantity">number of times</param>
        private void MoveHorizontal(int quantity)
        {
            HorizontalMovement += quantity;
        }

        /// <summary>
        /// Gets Manhattan Distance
        /// </summary>
        /// <returns>Manhattan Distance</returns>
        public int GetManhattanDistance()
        {

            return Math.Abs(VerticalMovement) + Math.Abs(HorizontalMovement);
        
        }

        /// <summary>
        /// Move the ship using a movement (Second part)
        /// </summary>
        /// <param name="movement">Movement to execute</param>
        private void MovePositionRelative(Movement movement)
        {
            switch (movement.Move)
            {
                case Movement.MoveEnum.F:

                    MoveHorizontal(HorizontalWayPoint* movement.Quantity);
                    MoveVertical(VerticalWayPoint * movement.Quantity);
                    break;

                case Movement.MoveEnum.N:

                    VerticalWayPoint += movement.Quantity;                     
                    break;

                case Movement.MoveEnum.S:

                    VerticalWayPoint -= movement.Quantity;
                    break;

                case Movement.MoveEnum.E:

                    HorizontalWayPoint += movement.Quantity;
                    break;

                case Movement.MoveEnum.W:

                    HorizontalWayPoint -= movement.Quantity;
                    break;

                case Movement.MoveEnum.R:

                    RotateShip((movement.Quantity / 90) % 4);
                    break;

                case Movement.MoveEnum.L:

                    RotateShip(((360 - movement.Quantity) / 90) % 4);
                    break;

            }
        }

        /// <summary>
        /// Rotates the ship the number of times desired
        /// </summary>
        /// <param name="spins">Number of times</param>
        private void RotateShip(int spins)
        {

            for (int i = 0; i < spins; i++)
            {
                int tempHorizontal = HorizontalWayPoint;
                int tempVertical = VerticalWayPoint;

                VerticalWayPoint = -1 * tempHorizontal;
                HorizontalWayPoint = tempVertical;

            }
        }

    }
}
