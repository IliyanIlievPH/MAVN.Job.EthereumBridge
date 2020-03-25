﻿using System;
using System.Threading.Tasks;
using Common;
using Lykke.Common.Log;
using Lykke.Job.EthereumBridge.Domain.Services;

namespace Lykke.Job.EthereumBridge.Services
{
    public class HangedOperationsService : TimerPeriod
    {
        private readonly IOperationsService _operationsService;

        public HangedOperationsService(
            IOperationsService operationsService,
            ILogFactory logFactory,
            TimeSpan idleTime)
            : base(idleTime, logFactory)
        {
            _operationsService = operationsService;
        }

        public override Task Execute()
        {
            return _operationsService.RepostHangedOperations();
        }
    }
}
