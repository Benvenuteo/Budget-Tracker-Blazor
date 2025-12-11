using Microsoft.JSInterop;

namespace BudgetTracker.BlazorWASM.Services
{
    public class ChartService
    {
        private readonly IJSRuntime _jsRuntime;

        public ChartService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task InitializePieChartAsync(string canvasId, string[] labels, decimal[] data, string[] colors)
        {
            // Wywołujemy funkcję z pliku chartInterop.js
            await _jsRuntime.InvokeVoidAsync("chartInterop.renderPieChart", canvasId, labels, data, colors);
        }
    }
}