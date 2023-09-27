using AutoMapper;
using G_Pigmy.App.DataControl.Interfaces;
using G_Pigmy.App.Mutation.Transaction.Command;
using GLib.Common;
using GLib.CQRS.Command.Abstractions;
using GLib.CQRS.Validation.Abstractions;
using dm = G_Pigmy.App.Models;

namespace G_Pigmy.App.Mutation.Transaction.Handler
{
    public class TransactionHandler : AbstractCommandHandler<TransactionCommand, Response>
    {
        private readonly ITransactionDataControl _dataControl;
        private readonly IMapper _mapper;

        public TransactionHandler(ITransactionDataControl dataControl, IMapper mapper, IValidator<TransactionCommand> validator) : base(validator)
        {
            _dataControl = dataControl;
            _mapper = mapper;
        }

        protected override async Task<Response> InternalHandleAsync(TransactionCommand command)
        {
            try
            {
                var transaction = _mapper.Map<dm.Transaction>(command);
                return await _dataControl.AddTransactionAsync(transaction); 
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
