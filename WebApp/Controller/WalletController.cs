using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Constants;
using WebApp.Core.Models;
using WebApp.Service.IServices;
using WebApp.Service.Services;

namespace WebApp.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IWalletService _walletService;
        public WalletController(IWalletService walletService)
        {
            _walletService = walletService;
        }
        [Authorize]
        [Route(WebApiEndpoint.Wallet.UpdateWalletByAccountId)]
        [HttpPut]
        public async Task<IActionResult> UpdateWalletByAccountId(WalletModelUpdateRequest model)
        {
            try
            {
               

                var updateWallet = await _walletService.UpdateWalletByAccountId(model.Balance);
                if (updateWallet == null)
                {
                    return NotFound();
                }
                return Ok(updateWallet);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while updating the role.");
            }
        }
    }
}
