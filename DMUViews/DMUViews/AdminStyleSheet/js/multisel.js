$('#btnRightGens').click(function (e) {
    var selGenres = $('#selectedGenres option:selected');
    if (selGenres.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#availGens').append($(selGenres).clone());
    $(selGenres).remove();
    e.preventDefault();
});




$('#btnLeftGens').click(function (e) {
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






$('#btnRightActs').click(function (e) {
    var selActors = $('#selectedActors option:selected');
    if (selActors.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#availActs').append($(selActors).clone());
    $(selActors).remove();
    e.preventDefault();
});



$('#btnLeftActs').click(function (e) {
    var selActors = $('#availActs option:selected');
    if (selActors.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#selectedGenres').append($(selActors).clone());
    $(selActors).remove();
    e.preventDefault();
});

$('#btnSubmit').click(function (e) {
    $('#selectedActors option').prop('selected', true);
});








$('#btnRightDirects').click(function (e) {
    var selDirectors = $('#selectedDirectors option:selected');
    if (selDirectors.length == 0) {
        alert("Nothing to move.");
        e.preventDefault();
    }

    $('#availDirects').append($(selDirectors).clone());
    $(selDirectors).remove();
    e.preventDefault();
});



$('#btnLeftDirects').click(function (e) {
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