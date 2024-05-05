import express from 'express';
import mysql from 'mysql';
import util from 'util';

//FIX para el __dirname
import path from 'path';
import { fileURLToPath } from 'url';
const __dirname = path.dirname(fileURLToPath(import.meta.url));
import { methods as authentication } from './controllers/autentificador.js';

//Servidor
const app = express();
app.set('port', 4000);
app.listen(app.get("port"));
console.log("Server on port", app.get("port"));

//Configuracion
app.use(express.static(__dirname + "/../../public"));
// Middleware para servir archivos .br
app.get('*.br', function (req, res, next) {
    res.set('Content-Encoding', 'br');
    next();
});


app.use(express.json());

//Rutas
app.get("/", (req, res) => {
    res.sendFile(path.join(__dirname + '/../../public/HTML/index.html'));
});
app.get("/register", (req, res) => {
    res.sendFile(path.join(__dirname + '/../../public/HTML/login.html'));
});
app.get("/login", (req, res) => {
    res.sendFile(path.join(__dirname + '/../../public/HTML/login.html'));
});

const dbConfig = {
    host: process.env.DB_HOST || 'localhost',
    user: process.env.DB_USER || 'root',
    password: process.env.DB_PASSWORD || '',
    database: process.env.DB_NAME || 'agrosims'
};

const pool = mysql.createPool(dbConfig);
const dbQuery = util.promisify(pool.query).bind(pool); 

// Ruta para obtener datos de ocupación
app.get('/api/ocupacion', (req, res) => {
    pool.getConnection((err, connection) => {
        if (err) {
            console.error('Error al conectar a la base de datos:', err);
            return res.status(500).send({ message: 'Error al conectar a la base de datos' });
        }

        const query = 'SELECT tipo_usuario, COUNT(*) AS count FROM usuario GROUP BY tipo_usuario';
        connection.query(query, (error, results) => {
            connection.release();
            if (error) {
                console.error('Error al realizar la consulta:', error);
                return res.status(500).send({ message: 'Error al realizar la consulta' });
            }
            res.send(results);
        });
    });
});

// Ruta para obtener datos de ocupación
app.get('/api/estados', (req, res) => {
    pool.getConnection((err, connection) => {
        if (err) {
            console.error('Error al conectar a la base de datos:', err);
            return res.status(500).send({ message: 'Error al conectar a la base de datos' });
        }

        const query = 'SELECT entidad, COUNT(*) AS count FROM usuario GROUP BY entidad';
        connection.query(query, (error, results) => {
            connection.release();
            if (error) {
                console.error('Error al realizar la consulta:', error);
                return res.status(500).send({ message: 'Error al realizar la consulta' });
            }
            res.send(results);
        });
    });
});

app.get('/api/edades', (req, res) => {
    pool.getConnection((err, connection) => {
        if (err) {
            console.error('Error al conectar a la base de datos:', err);
            return res.status(500).send({ message: 'Error al conectar a la base de datos' });
        }

        const query = "SELECT CASE WHEN TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 15 AND 20 THEN '15-20' WHEN TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 21 AND 25 THEN '21-25' WHEN TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 30 AND 35 THEN '30-35' WHEN TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 40 AND 50 THEN '40-50' WHEN TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 50 AND 60 THEN '50-60' WHEN TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 60 AND 70 THEN '60-70' END AS rango_edad, COUNT(*) AS cantidad, ROUND((COUNT(*) / (SELECT COUNT(*) FROM usuario WHERE TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 15 AND 70) * 100), 2) AS porcentaje FROM usuario WHERE TIMESTAMPDIFF(YEAR, fecha_nacimiento, CURDATE()) BETWEEN 15 AND 70 GROUP BY rango_edad ORDER BY rango_edad";

        connection.query(query, (error, results) => {
            connection.release();
            if (error) {
                console.error('Error al realizar la consulta:', error);
                return res.status(500).send({ message: 'Error al realizar la consulta' });
            }
            res.send(results);
        });
    });
});

app.get('/api/ranking', (req, res) => {
    pool.getConnection((err, connection) => {
        if (err) {
            console.error('Error al conectar a la base de datos:', err);
            return res.status(500).send({ message: 'Error al conectar a la base de datos' });
        }

        const query = "SELECT nombre_usuario, puntaje, decisiones_buenas, decisiones_intermedias, desciciones_malas, hora_inicio, hora_fin FROM partidas ORDER BY puntaje DESC, decisiones_buenas DESC, decisiones_intermedias DESC, desciciones_malas ASC";

        connection.query(query, (error, results) => {
            connection.release();
            if (error) {
                console.error('Error al realizar la consulta:', error);
                return res.status(500).send({ message: 'Error al realizar la consulta' });
            }
            res.send(results);
        });
    });
});

//Para el check del usuario
app.post('/check', async (req, res) => {
    try{
        let {usuario} = req.body; //Obtener el dato que te manda el usuario
        let query = 'SELECT * FROM usuario WHERE nombre_usuario = ?'; //Crea el query
        let resultado = await dbQuery(query, [usuario]); //Ejecuta el query con los datos que se le mandan

        console.log(resultado);

        //Cuando el usuario existe porque el resultado es mayor a 0. La query si saca información.
        if(resultado.length > 0){
            let horaInicial = new Date();
            let query2 = 'INSERT INTO partidas (nombre_usuario, hora_inicio) VALUES (?, ?)'; //Crea el query para llenar la tabla de ingresos

            //Verificar que el query2 se ejecute correctamente
            try{
                let resultado2 = await dbQuery(query2, [resultado[0].nombre_usuario, horaInicial]); //Manda la query y sustituye con los datos que se le mandan
                //console.log(resultado2);
                res.json(resultado2.insertId);
                return;
            }catch(error){
                console.log(error);
                // res.status(404).json({message: 'Usuario no ingreso correctamente'});
            }

        }else{
            res.status(400).json({message: 'Usuario no encontrado'}); //Si el usuario no existe, regresa un mensaje de que no se encontro el usuario
        }
    }catch(error){
        console.log(error);
    }
});

app.post('/salir', async (req, res) => {
    try{

        let {idPartida, total, decisionesBuenas, decisionesMalas, decisionesNeutras} = req.body; //Obtener el dato que te manda el usuario
        let query = 'UPDATE partidas SET decisiones_buenas =?, decisiones_intermedias =?, desciciones_malas =?, puntaje =?, hora_fin=? WHERE ID_partida =?'; //Crea el query
        let resultado = await dbQuery(query, [decisionesBuenas,decisionesNeutras,decisionesMalas,total,new Date(),idPartida]); //Ejecuta el query con los datos que se le mandan

        console.log(resultado);

    }catch(error){
        console.log(error);
    }
});

app.post('/elecciones', async (req, res) =>{
    try{

        let {financiamiento, seguro, agricultura, idPartida} = req.body; //Obtener el dato que te manda el usuario
        let query = 'INSERT INTO elecciones(seguro, tipo_agricultura, financiamiento) VALUES (?,?,?)'; //Crea el query
        let resultado = await dbQuery(query, [seguro, agricultura, financiamiento]); //Ejecuta el query con los datos que se le mandan
        //console.log(resultado);
        try{
            let ID_elecciones = resultado.insertId;
            let query2 = 'UPDATE partidas SET ID_elecciones = ? WHERE ID_partida = ?';
            await dbQuery(query2, [ID_elecciones, idPartida]);
            // res.json({ID_elecciones});
            return;
            //console.log(ID_elecciones);
        }catch(error){
            console.log(error);
        }

    }catch(error){
        console.log(error);
    }
});

app.post("/api/register", authentication.register);
app.post("/api/login", authentication.login);