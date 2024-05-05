const container = document.getElementById('container');
const registerBtn = document.getElementById('register');
const loginBtn = document.getElementById('login');


registerBtn.addEventListener('click', () => {
    container.classList.add("active");
});

loginBtn.addEventListener('click', () => {
    container.classList.remove("active");
});
/////Login
document.getElementById("login_form").addEventListener("submit", async (e) => {
    e.preventDefault();
    const res = await fetch("http://localhost:4000/api/login", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            correo_e: document.getElementById('correo_e').value,
            password: document.getElementById('password').value
        })
    });
    if (res.ok && res.redirected) {
        window.location.href = res.url;
    } else {
        const data = await res.json(); // Asumiendo que el servidor siempre responde con JSON
        if (data.alert) {
            alert(data.alert); // Muestra la alerta si el campo alert está presente
        }
    }


});

/////Register
document.getElementById('register_form').addEventListener('submit', async(e) => {
    e.preventDefault();
    const res = await fetch("http://localhost:4000/api/register", {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            nombre_u: document.getElementById('nombre_u').value,
            apellido_paterno_u: document.getElementById('apellido_paterno_u').value,
            apellido_materno_u: document.getElementById('apellido_materno_u').value,
            fecha_nacimiento_u: document.getElementById('fecha_nacimiento_u').value,
            entidad: document.getElementById('entidad').value,
            tipo_usuario: document.getElementById('tipo_usuario').value,
            nombre_usuario_u: document.getElementById('nombre_usuario_u').value,
            correo_electronico_u: document.getElementById('correo_electronico_u').value,
            contrasena_u: document.getElementById('contrasena_u').value
        })
    });
    if (res.ok && res.redirected) {
        window.location.href = res.url;
    } else {
        const data = await res.json(); // Asumiendo que el servidor siempre responde con JSON
        if (data.alert) {
            alert(data.alert); // Muestra la alerta si el campo alert está presente
        }
    }
});