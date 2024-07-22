﻿namespace Emlak_Projesi.Repositories.EstateAgentRepositories.DasboardRepositories.StatisticRepositories
{
    public interface IStatisticRepository
    {
        int ProductCountByEmployeeId(int id);
        int ProductCountByStatusTrue(int id);
        int ProductCountByStatusFalse(int id);
        int AllProductCount();
    }
}
