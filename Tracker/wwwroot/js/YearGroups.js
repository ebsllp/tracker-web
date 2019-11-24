let yearGroupId = 0;
let yearGroupCode = '';
let subjectId = 0;
let classId = 0;
let subject = '';
let objectives = [];
let assessTwice = 0;
let TermCode = ''
$(function () {
    yearGroups.loadYearGroups();
    yearGroups.loadObjectives();
    $("#yearGroupContainer").show();
});

var yearGroups = {
    loadYearGroups: function () {
        $("#subjectContainer").hide();
        $.ajax({
            url: '/YearGroups?handler=YearGroupsList'
        }).done(function (result) {
            let l = result.length;
            let i = 0;

            $("#yearGroups tbody").html("");
            while (i < l) {
                $("#yearGroups tbody").append("<tr><td><input type='button' assessTwice='" + result[i].assessTwicePerTerm + "' id='" + result[i].oid + "' code='" + result[i].code + "' onclick='yearGroups.loadSubjects(this)' value='Year " + result[i].code + "' class='yearGroupsButton btn btn-primary selectButtons' /></td></tr>");
                i++;
            }
            $(
                "#yearGroupContainer").show();
        });
    },
    loadSubjects: function (row) {
        if (row != undefined) {
            yearGroupId = $(row).attr("id");
            yearGroupCode = $(row).attr("code");
            assessTwice = $(row).attr("assessTwice");
        }
        $.ajax({
            url: '/YearGroups?handler=SubjectsList',
            data: {
                yearGroupId: yearGroupId
            }
        }).done(function (result) {
            let l = result.length;
            let i = 0;

            $("#yearGroupContainer").hide();
            $("#subjects tbody").html("");
            while (i < l) {
                $("#subjects tbody").append("<tr><td><input type='button' id='" + result[i].subjectId + "' code='" + result[i].displayName + "' onclick='yearGroups.loadTerms(this)' value='" + result[i].displayName + "' class='subjectButtons btn btn-primary selectButtons' /></td></tr>");
                i++;
            }
            $("#subjects tbody").append("<tr><td><input type='button' value='Back' onclick='yearGroups.loadYearGroups()' class='subjectButtons btn btn-warning selectButtons' /></td></tr>");
            $("#subjectContainer").show();
        });
    },
    loadTerms: function (row) {
        subjectId = $(row).attr("id");
        subject = $(row).attr("code");

        $("#subjectContainer").hide();
        $("#terms tbody").html("");

        $("#terms tbody").append("<tr><td><input type='button' id='termAutumn' code='AUT' onclick='yearGroups.loadPupils(this)' value='Autumn' class='termButtons btn btn-primary selectButtons' /></td></tr>");
        if (assessTwice > 0) {
            $("#terms tbody").append("<tr><td><input type='button' id='termAutumnHalf' code='AUT2' onclick='yearGroups.loadPupils(this)' value='Autumn Half' class='termButtons btn btn-primary selectButtons' /></td></tr>");
        }

        $("#terms tbody").append("<tr><td><input type='button' id='termSpring' code='SPR' onclick='yearGroups.loadPupils(this)' value='Spring' class='termButtons btn btn-primary selectButtons' /></td></tr>");
        if (assessTwice > 0) {
            $("#terms tbody").append("<tr><td><input type='button' id='termSpringHalf' code='SPR2' onclick='yearGroups.loadPupils(this)' value='Spring Half' class='termButtons btn btn-primary selectButtons' /></td></tr>");
        }

        $("#terms tbody").append("<tr><td><input type='button' id='termSummer' code='SUM' onclick='yearGroups.loadPupils(this)' value='Summer' class='termButtons btn btn-primary selectButtons' /></td></tr>");
        if (assessTwice > 0) {
            $("#terms tbody").append("<tr><td><input type='button' id='termSummerHalf' code='SUM2' onclick='yearGroups.loadPupils(this)' value='Summer Half' class='termButtons btn btn-primary selectButtons' /></td></tr>");
        }

        $("#terms tbody").append("<tr><td><input type='button' id='termTarget' code='TAR' onclick='yearGroups.loadPupils(this)' value='Target' class='termButtons btn btn-primary selectButtons' /></td></tr>");
        $("#terms tbody").append("<tr><td><input type='button' id='termBaseline' code='BAS' onclick='yearGroups.loadPupils(this)' value='Baseline' class='termButtons btn btn-primary selectButtons' /></td></tr>");

        $("#terms tbody").append("<tr><td><input type='button' value='Back' onclick='yearGroups.loadSubjects()' class='termButtons btn btn-warning selectButtons' /></td></tr>");
        $("#termContainer").show();
    },
    loadPupils: function (row) {
        termCode = $(row).attr("code");
        termName = $(row).val();

        $("#pupil-title").html('Year Group: ' + yearGroupCode + ', Subject: ' + subject + ', Term: ' + termName);
        $.ajax({
            url: '/YearGroups?handler=ClassId',
            data: {
                yearGroupId: yearGroupId,
                subjectId: subjectId
            }
        }).done(function (result) {
            classId = result;

            $.ajax({
                url: '/YearGroups?handler=TrackerPupils',
                data: {
                    yearGroupCode: yearGroupCode,
                    classId: classId
                }
            }).done(function (data) {
                $('.pupilTable').bootstrapTable({
                    data: data
                });
                $("#termContainer").hide();

                switch (termCode) {
                    case 'AUT' : {
                        $('.AUT').removeClass('hide-col');
                        break;
                    }
                    case 'AUT2': {
                        $('.AUT2').removeClass('hide-col');
                        break;
                    }
                    case 'SPR': {
                        $('.SPR').removeClass('hide-col');
                        break;
                    }
                    case 'SPR2': {
                        $('.SPR2').removeClass('hide-col');
                        break;
                    }
                    case 'SUM': {
                        $('.SUM').removeClass('hide-col');
                        break;
                    }
                    case 'SUM': {
                        $('.SUM').removeClass('hide-col');
                        break;
                    }
                    case 'SUM2': {
                        $('.SUM2').removeClass('hide-col');
                        break;
                    }
                }
                $("#pupilsContainer").show();
            });
        });
    },
    loadObjectives: function (row) {
        $.ajax({
            url: '/YearGroups?handler=ObjectivesList'
        }).done(function (result) {
            objectives = result;
        });
    },
    objectivesDropdown: function (value, row) {
        let l = objectives.length, i = 0;
        let html = '<select class="objectives">';
        while (i < l) {
            html += '<option value="' + objectives[i].id + '">' + objectives[i].description + '</option>';
            i++;
        }
        html += '</select>';
        return html;
    }
}