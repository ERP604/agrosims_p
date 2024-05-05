
const edades = document.getElementById('ageChart');
const estados = document.getElementById('stateChart');
const ocupacion = document.getElementById('jobChart');

/*Conexión a la BD de nuevo hasta que a
eduardo se le ocurra como simplificar 
y si no se le ocurre pos ya ni mode*/
// En admin.js, que está fuera del directorio 'src'

document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('stateChart').getContext('2d');
    fetch('/api/estados')
        .then(response => response.json())
        .then(data => {
            const labels = data.map(item => item.entidad);
            const counts = data.map(item => item.count);
            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: '',
                        data: counts,
                        borderWidth: 1,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.8)',
                            'rgba(54, 162, 235, 0.8)', 
                            'rgba(255, 206, 86, 0.8)', 
                            'rgba(75, 192, 192, 0.8)',
                            'rgba(255, 159, 64, 0.8)',
                            'rgba(153, 102, 255, 0.8)'
                        ]
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    },
                    responsive: true
                }
            });
        })
        .catch(error => console.error('Error al cargar los datos:', error));
});

document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('jobChart').getContext('2d');
    fetch('/api/ocupacion')
        .then(response => response.json())
        .then(data => {
            const labels = data.map(item => item.tipo_usuario);
            const counts = data.map(item => item.count);

            new Chart(ctx, {
                type: 'bar',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Usuarios por Tipo de Ocupación',
                        data: counts,
                        borderWidth: 1,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.8)',
                            'rgba(54, 162, 235, 0.8)', 
                            'rgba(255, 206, 86, 0.8)', 
                            'rgba(75, 192, 192, 0.8)',
                            'rgba(255, 159, 64, 0.8)',
                            'rgba(153, 102, 255, 0.8)'
                        ]
                    }]
                },
                options: {
                    scales: {
                        y: {
                            beginAtZero: true
                        }
                    },
                    responsive: true
                }
            });
        })
        .catch(error => console.error('Error al cargar los datos:', error));
});

document.addEventListener('DOMContentLoaded', function () {
    const ctx = document.getElementById('ageChart').getContext('2d');
    fetch('/api/edades')
        .then(response => response.json())
        .then(data => {
            const labels = data.map(item => item.rango_edad);
            const counts = data.map(item => item.porcentaje);

            new Chart(ctx, {
                type: 'doughnut',
                data: {
                    labels: labels,
                    datasets: [{
                        label: 'Usuarios por Edad',
                        data: counts,
                        borderWidth: 1,
                        backgroundColor: [
                            'rgba(255, 99, 132, 0.8)',
                            'rgba(54, 162, 235, 0.8)', 
                            'rgba(255, 206, 86, 0.8)', 
                            'rgba(75, 192, 192, 0.8)',
                            'rgba(153, 102, 255, 0.8)',
                            'rgba(153, 159, 64, 0.8)'  // Asegúrate de tener un color por cada rango de edad
                        ]
                    }]
                },
                options: {
                    responsive: true,
                    plugins: {
                        legend: {
                            position: 'left'
                        }
                    }
                }
            });
        })
        .catch(error => console.error('Error al cargar los datos:', error));
});

document.addEventListener('DOMContentLoaded', function () {
    $('#partidas').DataTable({
        ajax: {
            url: '/api/ranking',
            dataSrc: ''
        },
        columns: [
            { data: 'nombre_usuario' },
            { data: 'puntaje' },
            { data: 'decisiones_buenas' },
            { data: 'decisiones_intermedias' },
            { data: 'desciciones_malas' },
            { data: 'hora_inicio' },
            { data: 'hora_fin' }
        ],
        responsive: true
    });
});