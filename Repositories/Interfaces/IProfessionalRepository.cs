using BusinessObjects.Commons;
using BusinessObjects.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IProfessionalRepository : IGenericRepository<Professional>
    {
        //this for filter pro by spec/location
        public Task<IEnumerable<Professional>> SearchAsync( string? province = null,
                                                            string? district = null,
                                                            string? ward = null,
                                                            string? specialty = null,
                                                            string? professionalName = null);
    }
}
