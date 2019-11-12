let yearGroupId = 0;
let yearGroupCode = '';
let subjectId = 0;
let classId = 0;
let objectives = [];

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
                $("#yearGroups tbody").append("<tr><td><input type='button' id='" + result[i].oid + "' code='" + result[i].code + "' onclick='yearGroups.loadSubjects(this)' value='Year " + result[i].code + "' class='yearGroupsButton btn btn-primary selectButtons' /></td></tr>");
                i++;
            }
            $(
                "#yearGroupContainer").show();
        });
    },
    loadSubjects: function (row) {
        yearGroupId = $(row).attr("id");
        yearGroupCode = $(row).attr("code");

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
                $("#subjects tbody").append("<tr><td><input type='button' onclick='yearGroups.loadPupils(" + result[i].subjectId + ")' value='" + result[i].displayName + "' class='subjectButtons btn btn-primary selectButtons' /></td></tr>");
                i++;
            }
            $("#subjects tbody").append("<tr><td><input type='button' value='Back' onclick='yearGroups.loadYearGroups()' class='subjectButtons btn btn-warning selectButtons' /></td></tr>");
            $("#subjectContainer").show();
        });
    },
    loadPupils: function (_subjectId) {
        subjectId = _subjectId;

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
                $("#subjectContainer").hide();
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