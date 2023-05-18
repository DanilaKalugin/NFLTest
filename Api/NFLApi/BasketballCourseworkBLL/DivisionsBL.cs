using Coursework.DAL;
using Entities.Tables;

namespace Coursework.BLL
{
    public class DivisionsBL
    {
        private readonly DivisionsDAO _divisionsDao;

        public DivisionsBL(DivisionsDAO divisionsDao)
        {
            _divisionsDao = divisionsDao;
        }

        public async Task<List<NationalDivision>> GetConferencesAsync()
        {
            return await _divisionsDao.GetAllConferences()
                .ConfigureAwait(false);
        }
    }
}