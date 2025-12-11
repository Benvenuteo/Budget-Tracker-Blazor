window.chartInterop = {
    chartInstance: null,

    renderPieChart: (canvasId, labels, data, colors) => {
        // 1. Pobieramy element
        const canvas = document.getElementById(canvasId);

        // Sprawdzamy czy element istnieje
        if (!canvas) {
            console.warn(`Element canvas o id '${canvasId}' nie został znaleziony. Wykres nie zostanie wygenerowany w tym cyklu.`);
            return;
        }

        const ctx = canvas.getContext('2d');

        // Jeśli wykres już istnieje, niszczymy go przed narysowaniem nowego
        if (window.chartInterop.chartInstance) {
            window.chartInterop.chartInstance.destroy();
        }

        window.chartInterop.chartInstance = new Chart(ctx, {
            type: 'doughnut',
            data: {
                labels: labels,
                datasets: [{
                    data: data,
                    backgroundColor: colors,
                    borderWidth: 0,
                    hoverOffset: 4
                }]
            },
            options: {
                responsive: true,
                maintainAspectRatio: false,
                plugins: {
                    legend: {
                        position: 'right',
                        labels: {
                            font: {
                                family: "'Inter', sans-serif",
                                size: 12
                            },
                            usePointStyle: true
                        }
                    }
                },
                cutout: '75%'
            }
        });
    }
};