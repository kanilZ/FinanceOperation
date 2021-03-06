using AutoMapper;
using FinanceOperation.Core.Repositories;
using FinanceOperation.Domain.Cards;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceOperation.Core.Features.BankCards.GetList
{
    public class GetBankCardListQueryHandler : IRequestHandler<GetBankCardListQuery, IEnumerable<BankCardDto>>
    {
        private readonly IBankCardRepository _bankCardRepository;
        private readonly IMapper _mapper;

        public GetBankCardListQueryHandler(IBankCardRepository bankCardRepository, IMapper mapper)
        {
            _bankCardRepository = bankCardRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BankCardDto>> Handle(GetBankCardListQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<BankCard> bankCards = await _bankCardRepository.GetBankCardsList(cancellationToken);
            return _mapper.Map<IEnumerable<BankCardDto>>(bankCards);
        }
    }
}
