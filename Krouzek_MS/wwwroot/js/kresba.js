const platno = document.getElementById("canvas");
const platnoObrazek = document.getElementById("canvas-img");
let platnoKontext = platno.getContext("2d");
let platnoObrazekKontext = platnoObrazek.getContext("2d");


let draw_color = "black";
let draw_width = "5";
let is_drawing = false;

let start_background_color = "transparent"; //nastaveni zakladni barvy pozadi

nastavPlatno(platno, platnoKontext)
nastavPlatno(platnoObrazek, platnoObrazekKontext)


function nastavPlatno(platno, kontext){
    platno.width = 650;
    platno.height = 650;

    kontext.fillStyle = start_background_color; //pro tlacitko smazat
    kontext.fillRect(0,0, platno.width, platno.height);
}

function change_color(element) {
   draw_color = element.style.background;
}

platnoObrazek.addEventListener("touchstart",start,false);
platnoObrazek.addEventListener("touchmove",draw,false);
platnoObrazek.addEventListener("mousedown",start,false);
platnoObrazek.addEventListener("mousemove",draw,false);

platnoObrazek.addEventListener("touchend",stop,false);
platnoObrazek.addEventListener("mouseup",stop,false);
platnoObrazek.addEventListener("mouseout",stop,false);

function start (event) {
    is_drawing = true;
    platnoKontext.beginPath();
    platnoKontext.moveTo(event.clientX - platno.getBoundingClientRect().left,
        event.clientY - platno.getBoundingClientRect().top);
    event.preventDefault();
}

function draw(event){
    if (is_drawing){
        console.log(event.clientX, event.clientY, platno.offsetLeft, platno.offsetTop, platno.getBoundingClientRect().left)
        platnoKontext.lineTo(event.clientX - platno.getBoundingClientRect().left,
                       event.clientY - platno.getBoundingClientRect().top);
        platnoKontext.strokeStyle = draw_color;
        platnoKontext.lineWidth = draw_width;
        platnoKontext.lineCap ="round";
        platnoKontext.lineJoin = "round";
        platnoKontext.stroke();
    }
    event.preventDefault();

}

function stop(event){
    if (is_drawing){
        platnoKontext.stroke();
        platnoKontext.closePath();
        is_drawing = false;
    }
    event.preventDefault();
}

function clear_canvas() {
    platnoKontext.fillStyle = start_background_color;
    platnoKontext.clearRect(0,0, platno.width, platno.height);
    platnoKontext.fillRect(0,0, platno.width, platno.height);

    platnoObrazekKontext.fillStyle = start_background_color;
    platnoObrazekKontext.clearRect(0,0, platnoObrazek.width, platnoObrazek.height);
    platnoObrazekKontext.fillRect(0,0, platnoObrazek.width, platnoObrazek.height);
}

//platnoKontext.globalCompositeOperation = 'color';
function kralik(){
    clear_canvas();
    let kralik = new Image();
    kralik.src ="../images/kralik.png";
    platnoObrazekKontext.drawImage(kralik, 0,0)
}
function liska(){
    clear_canvas();
    const liska = new Image();
    liska.src ="../images/liskaO.png";
    platnoObrazekKontext.drawImage(liska, 0,0)
}

function sova(){
    clear_canvas();
    const sova = new Image();
    sova.src ="../images/sova.png";
    platnoObrazekKontext.drawImage(sova, 0,0)
}
function zaba(){
    clear_canvas();
    const zaba = new Image();
    zaba.src ="../images/zaba.png";
    platnoObrazekKontext.drawImage(zaba, 0,0)
}
