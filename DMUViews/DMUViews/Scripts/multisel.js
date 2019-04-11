$('#btnRightG').click(function (e) {
    var selGenres = $('#selectedGenres option:selected');
    if (selGenres.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#availGens').append($(selGenres).clone());
    $(selGenres).remove();
    e.preventDefault();
});




$('#btnLeftG').click(function (e) {
    var selGenres = $('#availGens option:selected');
    if (selGenres.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#selectedGenres').append($(selGenres).clone());
    $(selGenres).remove();
    e.preventDefault();
});

$('#btnSubmit').click(function (e) {
    $('#selectedGenres option').prop('selected', true);
});






$('#btnRightA').click(function (e) {
    var selActors = $('#selectedActors option:selected');
    if (selActors.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#availActs').append($(selActors).clone());
    $(selActors).remove();
    e.preventDefault();
});



$('#btnLeftA').click(function (e) {
    var selActors = $('#availActs option:selected');
    if (selActors.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#selectedActors').append($(selActors).clone());
    $(selActors).remove();
    e.preventDefault();
});

$('#btnSubmit').click(function (e) {
    $('#selectedActors option').prop('selected', true);
});








$('#btnRightD').click(function (e) {
    var selDirectors = $('#selectedDirectors option:selected');
    if (selDirectors.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#availDirects').append($(selDirectors).clone());
    $(selDirectors).remove();
    e.preventDefault();
});



$('#btnLeftD').click(function (e) {
    var selDirectors = $('#availDirects option:selected');
    if (selDirectors.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#selectedDirectors').append($(selDirectors).clone());
    $(selDirectors).remove();
    e.preventDefault();
});

$('#btnSubmit').click(function (e) {
    $('#selectedDirectors option').prop('selected', true);
});