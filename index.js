const $TeamWrapper = document.getElementById('team-wrapper');
const $TeamStats = document.getElementById('team-stats');
const $MainWrapper = document.getElementById('wrapper');

function ShowTeamInfo(event) {
    var elemId = event.currentTarget.id;

    fetch(`https://localhost:44314/Teams/team/${elemId}`)
    .then(response => response.json())
    .then(response => response.forEach(team => {
        document.querySelector(".team-container").classList.add('active');
        setTeam(team);
    }));
}

function setBackColor(team) {
    let primaryTeamColor = 'colors' in team ? team.colors[0].color : '#ffffff';
    let secondaryTeamColor = team.colors.length > 1 ? team.colors[1].color : primaryTeamColor;

    $TeamWrapper.style.backgroundColor = primaryTeamColor;
    document.getElementById('close').style.backgroundColor = primaryTeamColor;

    document.getElementById('team').style.backgroundImage = `linear-gradient(${team.teamRank}deg, ${primaryTeamColor}, ${secondaryTeamColor})`;
}

function setTeam(team) {
    fillTeamWrapper(team);
    fillTeamInfo(team);

    createCloseButton();
    setBackColor(team);
}

function createCloseButton() {

    let $CloseButtonWrapper = document.createElement('div');
    $CloseButtonWrapper.classList.add('stats-overview');

    let $CloseBtn = document.createElement('div');
    $CloseBtn.classList.add('close-btn');
    $CloseBtn.id = 'close';
    $CloseBtn.innerHTML = 'Close';
    $CloseBtn.onclick = closeInfo;

    $TeamStats.appendChild($CloseButtonWrapper);
    $CloseButtonWrapper.appendChild($CloseBtn);
}

function fillTeamWrapper(team) {

    var $teamLogo = document.createElement('div');

    $teamLogo.style.backgroundImage = `url(Logos/${team.teamAbbreviation}.png)`;
    $teamLogo.classList.add('team-info-team-logo');
    $TeamWrapper.appendChild($teamLogo);

    var $teamRegion = document.createElement('div');
    $teamRegion.classList.add('team-region');
    $teamRegion.id = 'team-region';
    $teamRegion.innerText = 'teamRegion' in team ? team.teamRegion : "";
    $TeamWrapper.appendChild($teamRegion);

    var $teamName = document.createElement('div');
    $teamName.classList.add('team-info-name');
    $teamName.id = 'team-name';
    $teamName.innerText = 'teamName' in team ? team.teamName : "";
    $TeamWrapper.appendChild($teamName);
}

function fillTeamInfo(team) {

    if ('stadium' in team) {
        appendTeamInfoToTable('Stadium', team.stadium.stadiumTitle);

        if ('stadiumLocation' in team.stadium)
        appendTeamInfoToTable('Location', `${team.stadium.stadiumLocation.cityTitle}, ${team.stadium.stadiumLocation.cityStateId}`);
    }

    if ('coach' in team) {
        appendTeamInfoToTable('Head Coach', team.coach);
    }

    if ('division' in team & 'divisionTitle' in team.division)
    {
        appendTeamInfoToTable('Division', team.division.divisionTitle);
    }

    if ('teamRank' in team)
    {
        appendTeamInfoToTable('Team Rank', team.teamRank);
    }
}

function appendTeamInfoToTable(header, value) {
    let $element = document.createElement('stats-overview');
    $element.setAttribute('key', header);
    $element.render();
    $TeamStats.appendChild($element);

    $element.setValue(value);
}

function closeInfo() {
    $TeamWrapper.innerHTML = "";
    $TeamStats.innerHTML = "";
    document.querySelector(".team-container").classList.remove('active');
}

window.onload = function callback(e) {
    fetch('https://localhost:44314/conferences')
    .then(response => response.json())
    .then(response => response.forEach(conference => AddConference(conference)))
}

function fillDivision(divisionNumber) {
    let $divisionWrapper = document.getElementById(`div${divisionNumber}`);

    fetch(`https://localhost:44314/Teams/division/${divisionNumber}`)
    .then(response => response.json())
    .then(response => response.forEach(team => {
        AddTeam(team, $divisionWrapper);
    }));
}

function AddTeam(team, divisionWrapper) {
        let $team = document.createElement('div');
        $team.classList.add('team');
        $team.id = team.teamAbbreviation;
        $team.setAttribute('style', `--team-color:${team.colors[0].color}`);

        let $teamLogo = document.createElement('img');
        $teamLogo.setAttribute('src', `Logos/${team.teamAbbreviation}.png`);
        $teamLogo.classList.add('team-logo');
        $team.appendChild($teamLogo);

        let $teamName = document.createElement('div');
        $teamName.classList.add('team-name');
        $teamName.innerText = `${team.teamRegion} ${team.teamName}`;
        $team.appendChild($teamName);

        $team.onclick = ShowTeamInfo;

        divisionWrapper.appendChild($team);
}

function AddConference(conference) {
    let $conferenceWrapper = document.createElement('div');
    $conferenceWrapper.classList.add('conference-wrapper');
    $conferenceWrapper.setAttribute('style', `--conf-color:${conference.conferenceColor}`);

    let $conferenceName = document.createElement('span');
    $conferenceName.classList.add('conference-name');
    $conferenceName.innerText = conference.conferenceName;

    $conferenceWrapper.appendChild($conferenceName);
    $MainWrapper.appendChild($conferenceWrapper);

    conference.divisions.forEach(division => AddDivision(division, $conferenceWrapper));
}

function AddDivision(division, conference) {
    let $divisionWrapper = document.createElement('div');
    $divisionWrapper.classList.add('division-wrapper');
    
    let $divisionName = document.createElement('span');
    $divisionName.classList.add('division-name');
    $divisionName.innerText = division.divisionTitle;

    let teamsInDivision = document.createElement('div');
    teamsInDivision.classList.add('division');
    teamsInDivision.id = `div${division.number}`;

    $divisionWrapper.appendChild($divisionName);
    $divisionWrapper.appendChild(teamsInDivision);
    conference.appendChild($divisionWrapper);

    fillDivision(division.number);
}