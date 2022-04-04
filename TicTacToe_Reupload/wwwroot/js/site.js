﻿var id = 1;

//Broadcast channel and two events to count opened pages.
const bc = new BroadcastChannel('test_channel');
bc.addEventListener('message', function (e) {
	sessionStorage.setItem("pages_counter", e.data);
})

window.onload = (event) => {
	id = Date.now();

	switch (sessionStorage.getItem("pages_counter")) {
		case null:
			sessionStorage.setItem("pages_counter", "1");
			break;
		case "0":
			sessionStorage.setItem("pages_counter", "1");
			break;
		case "1":
			sessionStorage.setItem("pages_counter", "2");
			break;
		case "2":
			sessionStorage.setItem("pages_counter", "3");
			break;
		case "3":
			sessionStorage.setItem("pages_counter", "4");
			window.close();
			break;
		default:
			sessionStorage.setItem("pages_counter", "1");
			break;
	}
	bc.postMessage(sessionStorage.getItem("pages_counter"));
}

window.onunload = (event) => {
	switch (sessionStorage.getItem("pages_counter")) {
		case null:
			sessionStorage.setItem("pages_counter", "0");
			break;
		case "0":
			sessionStorage.setItem("pages_counter", "0");
			break;
		case "1":
			sessionStorage.setItem("pages_counter", "0");
			break;
		case "2":
			sessionStorage.setItem("pages_counter", "1");
			break;
		case "3":
			sessionStorage.setItem("pages_counter", "2");
			break;
		case "4":
			sessionStorage.setItem("pages_counter", "3");
			break;
		default:
			break;
	}
	bc.postMessage(sessionStorage.getItem("pages_counter"));
};

// Function to reset game
function myfunc_reset() {
	location.reload();
	for (let i = 1; i <= 9; ++i) {
		document.getElementById('box' + i).value = '';
		document.getElementById('box' + i).disabled = false;
	}
	document.getElementById('print').value = '';
	flag = 1;
}

// Function to run a report
function myfunc_report() {
	$.get("/Home/RunReport", mybody, function (data) {});
}
// Function called whenever user tab on any box
function get_jquery() {
	const box = [];
	for (let i = 1; i <= 9; i++) {
		box[i] = document.getElementById("box" + i).value;
	}
	var mybody = {
		allData: "",
		myid: id
	};
	mybody.allData += " ";          // Здесь был id, но он перестал быть однозначным.
	for (let i = 1; i <= 9; i++) {
		mybody.allData += (box[i] != '') ? box[i] : 'n';
	}
	mybody.allData += flag;
	//window.alert("Data: " + mybody.allData);

	$.post("/Home/InnerLogic", mybody, function (data) {
		//window.alert("Data: " + data);
		if (data == "X won") {
			document.getElementById('print').innerHTML = "Player X won";
			for (let i = 1; i <= 9; ++i) {
				document.getElementById("box" + i).disabled = true;
			}
			window.alert('Player X won');
		} else {
			if (data == "0 won") {
				document.getElementById('print').innerHTML = "Player 0 won";
				for (let i = 1; i <= 9; ++i) {
					document.getElementById("box" + i).disabled = true;
				}
				window.alert('Player 0 won');
			} else {
				if (data == "Match tie") {
					document.getElementById('print').innerHTML = "Match tie";
					for (let i = 1; i <= 9; ++i) {
						document.getElementById("box" + i).disabled = true;
					}
					window.alert('Match tie');
				} else {
					if (flag == 1) {
						document.getElementById('print')
							.innerHTML = "Player X Turn";
					}
					else {
						document.getElementById('print')
							.innerHTML = "Player 0 Turn";
					}
				}
			}
		}
		//window.alert("Data: " + data + "\nStatus: " + status);
	});
}

// Here onwards, functions check turn of the player
// and put accordingly value X or 0
flag = 1;
function myfunc_1() {
	if (flag == 1) {
		document.getElementById("box1").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box1").value = "0";
		flag = 1;
	}
	document.getElementById("box1").disabled = true;
}

function myfunc_2() {
	if (flag == 1) {
		document.getElementById("box2").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box2").value = "0";
		flag = 1;
	}
	document.getElementById("box2").disabled = true;
}

function myfunc_3() {
	if (flag == 1) {
		document.getElementById("box3").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box3").value = "0";
		flag = 1;
	}
	document.getElementById("box3").disabled = true;
}

function myfunc_4() {
	if (flag == 1) {
		document.getElementById("box4").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box4").value = "0";
		flag = 1;
	}
	document.getElementById("box4").disabled = true;
}

function myfunc_5() {
	if (flag == 1) {
		document.getElementById("box5").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box5").value = "0";
		flag = 1;
	}
	document.getElementById("box5").disabled = true;
}

function myfunc_6() {
	if (flag == 1) {
		document.getElementById("box6").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box6").value = "0";
		flag = 1;
	}
	document.getElementById("box6").disabled = true;
}

function myfunc_7() {
	if (flag == 1) {
		document.getElementById("box7").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box7").value = "0";
		flag = 1;
	}
	document.getElementById("box7").disabled = true;
}

function myfunc_8() {
	if (flag == 1) {
		document.getElementById("box8").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box8").value = "0";
		flag = 1;
	}
	document.getElementById("box8").disabled = true;
}

function myfunc_9() {
	if (flag == 1) {
		document.getElementById("box9").value = "X";
		flag = 0;
	}
	else {
		document.getElementById("box9").value = "0";
		flag = 1;
	}
	document.getElementById("box9").disabled = true;
}
