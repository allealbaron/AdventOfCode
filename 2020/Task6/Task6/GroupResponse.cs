using System.Collections.Generic;
using System.Linq;

namespace Task6
{
    /// <summary>
    /// Represents Group Response
    /// </summary>
    class GroupResponse
    {
        /// <summary>
        /// Number of persons which integrate the group
        /// </summary>
        public int Members;

        /// <summary>
        /// Responses
        /// </summary>
        public Dictionary<char, int> Responses;

        /// <summary>
        /// Class Builder
        /// </summary>
        public GroupResponse()
        {

            this.Members = 0;
            this.Responses = new Dictionary<char, int>();

        }

        /// <summary>
        /// List of questions answered by everybody
        /// </summary>
        public List<char> AnsweredByEveryBody => Responses.Where(p => p.Value == Members).Select(k => k.Key).ToList<char>();

    }

   
}
