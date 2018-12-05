using System;
using System.Linq;
using System.Threading.Tasks;
using WipKata.Core.Interfaces;
using WipKata.Core.Types;

namespace WipKata.Infrastructure
{
    public class CardProcessor : ICardProcessor
    {
        private readonly ITimerFactory _timerFactory;
        private readonly ICardProcessService _cardProcessService;
        private readonly IOutputProvider _outputProvider;

        public CardProcessor(ITimerFactory timerFactory, 
            ICardProcessService cardProcessService, 
            IOutputProvider outputProvider)
        {
            _timerFactory = timerFactory;
            _cardProcessService = cardProcessService;
            _outputProvider = outputProvider;
        }

        public void RunAllSequences()
        {
            foreach (var sequenceType in Enum.GetValues(typeof(WipType)).Cast<WipType>())
            {
                ProcessCards(sequenceType);
            }
        }


        private void ProcessCards(WipType sequenceType)
        {
            _outputProvider.OutputLine();
            _outputProvider.OutputLine("********************");
                        
            var queueTimer = _timerFactory.CreateTimer($"{sequenceType} Queue");

            queueTimer.Start();

            Parallel.Invoke(_cardProcessService.GetCardHandlers(sequenceType)
                .Select(cardHandler => (Action) cardHandler.ApplyStickersToDots)
                .ToArray());

            queueTimer.Stop();
        }
    }
}