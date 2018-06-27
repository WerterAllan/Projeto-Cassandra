﻿namespace Werter.ProjetoCassandra.Domain.StoreContext.FluentBuilder
{
    public abstract class FluentBuilderBase<T> where T : class
    {
        public abstract T Build();

    }
}
