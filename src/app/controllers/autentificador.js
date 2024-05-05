import mysql from 'mysql';
import bcryptjs from 'bcryptjs';
import dotenv from 'dotenv';
import { json } from 'express';

dotenv.config();
// Configuración de la conexión a la base de datos
const dbConfig = {
    host: 'localhost',
    user: 'root',
    password: '',
    database: 'agrosims'
};
const pool = mysql.createPool(dbConfig);

function getConnection(callback) {
  pool.getConnection((err, connection) => {
    if (err) {
      console.error('Error al conectar a la base de datos:', err);
      return callback(err, null);
    }
    console.log("Conexión a la base de datos establecida");
    callback(null, connection);
  });
}

async function login(req, res) {
  console.log(req.body);
  const { correo_e, password } = req.body;

  if (!correo_e || !password) {
    return res.status(400).send({alert: 'Faltan datos de usuario o contraseña'});
  }

  // Comprobación de correos especiales
  const adminRegex = /@(verqor\.com|agrosims\.com)$/i;
  const isAdmin = adminRegex.test(correo_e);

  getConnection((err, connection) => {
    if (err) {
      return res.status(500).send({alert: 'Error al conectar con la base de datos'});
    }

    const query = 'SELECT * FROM usuario WHERE Correo = ?';
    connection.query(query, [correo_e], (error, results) => {
      connection.release();
      if (error) {
        return res.status(500).send({alert: 'Error al consultar la base de datos'});
      }
      if (results.length === 0) {
        return res.status(404).send({alert: 'Usuario no encontrado'});
      }

      const user = results[0];
      bcryptjs.compare(password, user.contrasena, (err, isMatch) => {
        if (err) {
          return res.status(500).send({alert: 'Error al verificar la contraseña'});
        }
        if (!isMatch) {
          return res.status(401).send({alert: 'Contraseña incorrecta'});
        }

        // Redirect based on email type
        const redirectPage = isAdmin ? 'index2.html' : 'index3.html';
        console.log(`Login exitoso y redireccionado a ${redirectPage}`);
        res.redirect(`${req.protocol}://${req.get('host')}/HTML/${redirectPage}`);
      });
    });
  });
}




/////Register
async function register(req, res) {
  console.log(req.body);
  const { nombre_u, apellido_paterno_u, apellido_materno_u, fecha_nacimiento_u, entidad, tipo_usuario, nombre_usuario_u, correo_electronico_u, contrasena_u } = req.body;

  if (!nombre_u || !apellido_paterno_u || !apellido_materno_u || !fecha_nacimiento_u || !entidad || !tipo_usuario || !nombre_usuario_u || !correo_electronico_u || !contrasena_u) {
    return res.status(400).send({alert: 'Faltan datos'});
  }

  getConnection((err, connection) => {
    if (err) {
      return res.status(500).send({alert: 'Error al conectar con la base de datos'});
    }

    // Verificar si el usuario ya está registrado
    connection.query('SELECT * FROM usuario WHERE Correo = ?', [correo_electronico_u], (error, results) => {
      if (error) {
        connection.release();
        return res.status(500).send({alert: 'Error al verificar el usuario'});
      }
      if (results.length > 0) {
        connection.release();
        return res.status(400).send({status: "Error", alert: 'Usuario ya registrado'});
      }

      // Proceso de creación del nuevo usuario
      bcryptjs.genSalt(10, (err, salt) => {
        bcryptjs.hash(contrasena_u, salt, (err, contrasenaEncriptada) => {
          const query = 'INSERT INTO usuario (Nombre, apellido_paterno, apellido_materno, fecha_nacimiento, entidad, tipo_usuario, correo, nombre_usuario, contrasena) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)';
          connection.query(query, [nombre_u, apellido_paterno_u, apellido_materno_u, fecha_nacimiento_u, entidad, tipo_usuario, correo_electronico_u, nombre_usuario_u, contrasenaEncriptada], (error, result) => {
            connection.release();
            if (error) {
              return res.status(500).send({alert: 'Error al registrar el usuario'});
            }
            res.redirect(`${req.protocol}://${req.get('host')}/HTML/login.html`);
          });
        });
      });
    });
  });
}




//Exportar métodos
export const methods = {
    login, 
    register
}
