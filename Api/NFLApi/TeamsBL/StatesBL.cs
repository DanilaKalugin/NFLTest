using Entities.Tables;
using NFL.DAO;

namespace NCAA.BLL;

public class StatesBL
{

    private readonly StatesDAO _statesDao;

    public StatesBL(StatesDAO StatesDao)
    {
        _statesDao = StatesDao;
    }

    public async Task<List<State>> GetStatesAsync() =>
        await _statesDao.GetStatesAsync()
            .ConfigureAwait(false);

    public async Task<State?> GetStateByStateCodeAsync(string stateCode) =>
        await _statesDao.GetStateById(stateCode)
            .ConfigureAwait(false);
}