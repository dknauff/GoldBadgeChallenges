using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Claims_Challenge_ClassLibrary
{
    public class ClaimRepository
    {
        protected readonly Queue<ClaimClass> _claimDirectory = new Queue<ClaimClass>();

        public bool AddClaimToDirectory(ClaimClass claim)
        {
            int startingCount = _claimDirectory.Count;
            _claimDirectory.Enqueue(claim);
            bool wasAdded = (_claimDirectory.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public Queue<ClaimClass> GetAllClaims()
        {
            return _claimDirectory;
        }

        public ClaimClass PeekQueue()
        {
            return _claimDirectory.Peek();
        }
        public ClaimClass DeQueueClaim()
        {
            return _claimDirectory.Dequeue();
        }
    }
}
