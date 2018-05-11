/*

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

// 소켓으로 메시지가 날아올때의 값 socket.id를 어딘가에 저장해놨다가 그놈한테 보내줄때 쓰면 된다.
var id;

// IP:PORT/socket 의 주소에 소켓을 만든다. 연결이되면 function 이하 구문이 실행된다.
// 클라이언트에서 보낼때 conn 이라는 키로 보내게되며 값인 data를 받게된다.
var sign = io.of('/socket')
    .on('connection', function (socket) {
        id = socket.id;
        socket.on('conn', function (value, acks) {
            console.log(value);

            // send 'woot' string as an ack message
            acks('true');
        });

    });

// 이 아래 과정에서 sign 이라는 이름의 소켓에 여러 키를 통해 값들을 보내게 된다.
// 받는 쪽에서 키에 대한 설정이 되어있으면 받을 수 있고 없으면 받을 수 없다.
function enrollSuccess () {
    console.log("enrollSuccess()");
    sign.to(id).emit('enroll', 'true');
}

function enrollFail () {
    console.log("enrollFail()");
    sign.to(id).emit('enroll', 'false');
}

function scenarioChange () {
    console.log("scenarioChange()");
    sign.to(id).emit('scenarioChange', 'true');
}

var testname = "test name";
function scenarioStart () {
    console.log("scenarioStart()");
    sign.to(id).emit('scenarioStart', testname); // TODO test name 에 대한 기입
}

server.listen(3332, function() {
    console.log('Socket IO server listening on port 3332');
});

*/