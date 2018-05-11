var app = require('express')();
var server = require('http').createServer(app);
// http server를 socket.io server로 upgrade한다
var io = require('socket.io')(server);

// get 방식이기 때문에 브라우저에서 IP:PORT/주소 로 접속하면 각 함수를 실행한다

app.get('/enrollSuccess', function(req, res) {
    res.sendFile(__dirname + '/index.html'); // socket 에서 중요한 부분은 아닌듯. index.html을 보여주기위한 것?
    enrollSuccess();
});

app.get('/enrollFail', function(req, res) {
    res.sendFile(__dirname + '/index.html');
    enrollFail();
});

app.get('/scenarioChange', function(req, res) {
    res.sendFile(__dirname + '/index.html');
    scenarioChange();
});

app.get('/scenarioStart', function(req, res) {
    res.sendFile(__dirname + '/index.html');
    scenarioStart();
});


// IP:PORT/socket 의 주소에 소켓을 만든다.  연결이되면 function 이하 구문이 실행된다.
var sign = io.of('/socket')
    .on('connection', function (socket) {

        socket.on('conn', function (data, acks) {
            console.log(data);

            // send 'woot' string as an ack message
            acks('true');
        });

    });

server.listen(3332, function() {
    console.log('Socket IO server listening on port 3332');
});

function enrollSuccess () {
    console.log("enrollSuccess()");
    sign.emit('enroll', 'true');
}

function enrollFail () {
    console.log("enrollFail()");
    sign.emit('enroll', 'false');
}

function scenarioChange () {
    console.log("scenarioChange()");
    sign.emit('scenarioChange', 'true');
}

var testname = "test name";
function scenarioStart () {
    console.log("scenarioStart()");
    sign.emit('scenarioStart', testname); // TODO test name 에 대한 기입
}

