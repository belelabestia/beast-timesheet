# Beast Timesheet (BTS)

Minimal web app for tracking work timesheets.

> I just had the idea to call it Beast-Billy (BB) since its final goal is to assist me with my billing.

## Need

The reason why I'm creating this app is that I'm currently using my remarkable or excel to keep track of the work on my projects and I'd like to have a dedicated tool for that.

## Concept

I'm currently tracking the following **project data**:

- **Project name**: usually the customer name
- **Hourly fee**: the agreed hourly rate for the job

Within a _project_ I create many _timesheets_; a **timesheet** is just a collection of _sessions_ with the following data:

- **Name**: usually the billing period (month)
- **State**: **open** (in use) or **closed** (already billed)

I have one open timesheet at a time.

When working on a project, I daily track the following **session data** on the current _timesheet_:

- **Date**: the current day of the session
- **Start time**: the time I start working
- **Stop time**: the time I stop working
- **Breaks time**: the total time spent on breaks, not to be counted
- **Gross time**: (calculated) the time span from start to stop
- **Net time**: (calculated) the _gross time_ minus the _breaks time_
- **Session fee**: (calculated) the _net time_ times the _hourly fee_

When I need to bill, I extract the following **bill data**:

- **Bill name**, from the _project name_ and the _timesheet name_
- **Worked hours**, as the sum of all the _session net times_
- **Total fee**, as the sum of all the _session fees_

The _bill data_ is used to get my client to approve my bill before I send it.

Once I've emitted my _bill_, I need to track the following:

- **Expiration**: the expiration date for paying the bill
- **Payed**: if the bill has been payed
- **State**: (calculated) **emitted** (not payed and not expired yet) or **payed** (payed whenever expired or not) or **expired** (expired and not payed)

## Technology

I'd like to use Blazor Wasm for this project, so both FE and BE.

No CSS framework, I'm defining my own minimal styles.

I'll use Postgres as database, with EF Core as ORM.

I'll develop and deploy the application stack with Docker Compose.

## Security

The application will be protected under **basic authentication** and be available only for me (one only tenant and user).

## UI/UX

The web app (PWA) will prompt login on landing, with the following elements:

- **Username**: the username for login
- **Password**: the password for login
- **Enter button**: a button to attempt login (also enter on keyboard)

On failed login the app just gives a feedback message. 

After login the app will present the _projects_ view:

- **Title**: projects
- **Toolbar**: an area with filters and sorting options (by state, date, ecc)
- **Project list**: a list of all the projects

By opening a _project_, the app will navigate to the _project_ view:

- **Title**: _project name_
- **Back button**: navigates back to _projects_ view
- **Project overview**: an area presenting the _project data_ with the partial (or complete) aggregated data from the _timesheets_
- **Timesheet list**: a list of al the _project timesheets_

By clicking on any _timesheet_, the app will navigate to its view:

- **Title**: the _timesheet name_
- **Back button**: navigates back to _project_ view
- **Session list**: a list of all the _sessions_
- **Add session button**: opens a prompt for creating a new _session_

By clicking on any _timesheet_, the app navigates to a form that shows all _timesheet_ data and enables the user to edit it.

All entities can also be archived (soft remove) or deleted (hard remove).

> I'm noticing that the UI structure is quite straightforward for most views, so probably title and navigation can be put in an external shell.
>
> And something similar can be done for the bills.

The _bills_ view should be optionally by project or global, so I can just have a fast report of all my bills.

## Repo scripts

The root of this repo acts like a little console. I'm intentionally keeping the sripts in the root for extra-practical purposes.

If working on other than Windows, please install [the cross-platform PowerShell](https://github.com/PowerShell/PowerShell).

Run `./ls.ps1` to quickly show all the `ps1` scripts available; they all batch small sequences of commands (some may contain just one command!) and are useful both for use and consultation.

## Move sessions from one timesheet to another

I'll show an overlay with the possible destination timesheets and a _cancel_ button.