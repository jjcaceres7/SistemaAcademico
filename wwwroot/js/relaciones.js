window.onload = function () {
    //const datos = JSON.parse('@Html.Raw(Model.DatosJson)');
    //console.log(DatosJson);

    

    // document.getElementById("muestra").innerHTML = window.DatosDelServidor;
    var Autores = Object.values(DatosDelServidorAutores);
    var Libros = window.DatosDelServidor;

    let tBody = document.createElement("tbody");

    //console.log(Autores);
    //console.log(Libros);

    const Relaciones = {};
    Autores.forEach(e => {
        // console.log(e.Id);
        Relaciones[e.Id] = [];
        Libros.forEach(l => {
            if (e.Id == l.Autor) {
                Relaciones[e.Id].push(l);
            }
        });

    });
    console.log(Relaciones);

    Autores.forEach(a => {
        
        var nameAutor = a.Name;
        Relaciones[a.Id].forEach(r => {
            let tr = document.createElement("tr");
            tr.innerHTML = `<td>${nameAutor}</td><td>${r.Title}</td><td>${r.Id}</td><td>${r.Year}</td><td>${r.Genders}</td>`
            tBody.appendChild(tr);
            nameAutor = "  ";
        });



    });

    document.getElementById("tablaRelaciones").appendChild(tBody);
    
    





}

function imprimir() {
    window.print();
}