using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task11
{
    /// <summary>
    /// Waiting Room
    /// </summary>
    class WaitingRoom
    {

        /// <summary>
        /// Room configuration
        /// </summary>
        public List<List<char>> RoomConfiguration;

        /// <summary>
        /// Class Builder
        /// </summary>
        public WaitingRoom()
        {
            RoomConfiguration = new List<List<char>>();
        }

        /// <summary>
        /// Clones room
        /// </summary>
        /// <param name="room">Room to clone</param>
        /// <returns>Cloned room</returns>
        private List<List<char>> CloneRoom(List<List<char>> room)
        {
            List<List<char>> result = new List<List<char>>();

            for (int i = 0; i < room.Count; i++)
            {
                List<char> tempRow = new List<char>();
                for (int j = 0; j < room[i].Count; j++)
                {
                    tempRow.Add(room[i][j]);
                }
                result.Add(tempRow);
            }

            return result;

        }

        /// <summary>
        /// Prints room configuration
        /// </summary>
        /// <param name="room">Room</param>
        public void PrintRoom(List<List<char>> room)
        {
            for (int i = 0; i < room.Count; i++)
            {
                for (int j = 0; j < room[i].Count; j++)
                {
                    Console.Write("{0}", room[i][j]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Returns the number of seats occupied
        /// </summary>
        /// <param name="room">Room</param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int GetOccupiedAdyacentSeats(List<List<char>> room, int i, int j)
        {
            int result = 0;

            if (i > 0)
            {
                if (j > 0)
                {
                    if (room[i - 1][j - 1].Equals('#'))
                    {
                        result++;
                    }
                }

                if (room[i - 1][j].Equals('#'))
                {
                    result++;
                }

                if (j < room[i].Count - 1)
                {
                    if (room[i - 1][j + 1].Equals('#'))
                    {
                        result++;
                    }
                }

            }

            if (j > 0)
            {
                if (room[i][j - 1].Equals('#'))
                {
                    result++;
                }
            }

            if (j < room[i].Count - 1)
            {
                if (room[i][j + 1].Equals('#'))
                {
                    result++;
                }
            }

            if (i < room.Count - 1)
            {
                if (j > 0)
                {
                    if (room[i + 1][j - 1].Equals('#'))
                    {
                        result++;
                    }
                }

                if (room[i + 1][j].Equals('#'))
                {
                    result++;
                }

                if (j < room[i+1].Count - 1)
                {
                    if (room[i + 1][j + 1].Equals('#'))
                    {
                        result++;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Fills waiting room for problem 1
        /// </summary>
        /// <returns>Number of occupied seats</returns>
        public int FillWaitingRoom()
        {

            List<List<char>> temp;

            bool blnOneChange = true;

            while (blnOneChange)
            {
                blnOneChange = false;

                temp = CloneRoom(RoomConfiguration);

                for (int i = 0; i < temp.Count; i++)
                {
                    for (int j = 0; j < temp[i].Count; j++)
                    {

                        int occupiedSeats = GetOccupiedAdyacentSeats(RoomConfiguration, i, j);
                       
                        if (temp[i][j].Equals('L') && occupiedSeats == 0)
                        {
                            temp[i][j] = '#';
                            blnOneChange = true;
                        }
                        else
                        {
                            if (temp[i][j].Equals('#') && occupiedSeats >= 4)
                            {
                                temp[i][j] = 'L';
                                blnOneChange = true;
                            }
                        }
                    }
                }

               RoomConfiguration = CloneRoom(temp);

            }

            return GetCount();

        }

        /// <summary>
        /// Returns number of occupied seats
        /// </summary>
        /// <returns>Number of occupied seats</returns>
        private int GetCount()
        {
            return  (from line in RoomConfiguration
                     from i in Enumerable.Range(0, line.Count)
                     where line[i] == '#'
                     group line by line into g
                     select new { Count = g.Count() }).Sum(g => g.Count);

        }

        int CheckSeat(char seat)
        {
            if (seat == 'L')
            {
                return 0;
            }

            if (seat == '#')
            {
                return 1;
            }

            return -1;

        }

        /// <summary>
        /// Returns the number of seats occupied
        /// </summary>
        /// <param name="room">Room</param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        public int GetOccupiedAdyacentSeatsPart2(List<List<char>> room, int i, int j)
        {
            int result = 0;
            int k;

            if (i > 0)
            {
                if (j > 0)
                {
                    k = 1;

                    while (i - k >= 0 && j - k >= 0)
                    {
                        if (CheckSeat(room[i - k][j - k]) >= 0)
                        {
                            if (CheckSeat(room[i - k][j - k]) == 1)
                            {
                                result++;
                            }
                            k = room.Count;
                        }
                      
                        k++;
                    }
                }

                k = 1;

                while (i - k >= 0)
                {
                    if (CheckSeat(room[i - k][j]) >= 0)
                    {
                        if (CheckSeat(room[i - k][j]) == 1)
                        {
                            result++;
                        }
                        k = room.Count;
                    }

                    k++;
                }

                if (j < room[i].Count - 1)
                {
                    k = 1;
                    while (i - k >= 0 && j + k < room[i].Count)
                    {
                        if (CheckSeat(room[i - k][j + k]) >= 0)
                        {
                            if (CheckSeat(room[i - k][j + k]) == 1)
                            {
                                result++;
                            }
                            k = room.Count;
                        }
                        k++;
                    }
                }

            }

            if (j > 0)
            {
                k = 1;
                while (j - k >= 0)
                {
                    if (CheckSeat(room[i][j - k]) >= 0)
                    {
                        if (CheckSeat(room[i][j - k]) == 1)
                        {
                            result++;
                        }
                        k = room.Count;
                    }

                    k++;
                }
            }

            if (j < room[i].Count)
            {
                k = 1;

                while (j + k < room[i].Count)
                {
                    if (CheckSeat(room[i][j + k]) >= 0)
                    {
                        if (CheckSeat(room[i][j + k]) == 1)
                        {
                            result++;
                        }
                        k = room.Count;
                    }

                    k++;
                }
            }

            if (i < room.Count-1)
            {
                if (j > 0)
                {
                    k = 1;

                    while (i + k <= room.Count-1 && j - k >= 0)
                    {
                        if (CheckSeat(room[i + k][j - k]) >= 0)
                        {
                            if (CheckSeat(room[i + k][j - k]) == 1)
                            {
                                result++;
                            }
                            k = room.Count;
                        }

                        k++;
                    }
                }

                k = 1;

                while (i + k <= room.Count-1)
                {
                    if (CheckSeat(room[i + k][j]) >= 0)
                    {
                        if (CheckSeat(room[i + k][j]) == 1)
                        {
                            result++;
                        }
                        k = room.Count;
                    }

                    k++;
                }

                if (j < room[i].Count - 1)
                {
                    k = 1;
                    while (i + k < room.Count  && j + k < room[i+k].Count )
                    {
                        if (CheckSeat(room[i + k][j + k]) >= 0)
                        {
                            if (CheckSeat(room[i + k][j + k]) == 1)
                            {
                                result++;
                            }
                            k = room.Count;
                        }
                        k++;
                    }
                }

            }

            return result;

        }

        /// <summary>
        /// Fills waiting room for problem 2
        /// </summary>
        /// <returns>Number of occupied seats</returns>
        public int FillWaitingRoomPart2()
        {

            List<List<char>> temp;

            bool blnOneChange = true;

            while (blnOneChange)
            {
                blnOneChange = false;

                temp = CloneRoom(RoomConfiguration);

                for (int i = 0; i < temp.Count; i++)
                {
                    for (int j = 0; j < temp[i].Count; j++)
                    {
                        int occupiedSeats = GetOccupiedAdyacentSeatsPart2(RoomConfiguration, i, j);

                        if (temp[i][j].Equals('L') && occupiedSeats == 0)
                        {
                            temp[i][j] = '#';
                            blnOneChange = true;
                        }
                        else
                        {
                            if (temp[i][j].Equals('#') && occupiedSeats >= 5)
                            {
                                temp[i][j] = 'L';
                                blnOneChange = true;
                            }
                        }
                    }
                }

                RoomConfiguration = CloneRoom(temp);

            }

            return GetCount();

        }

    }
}
