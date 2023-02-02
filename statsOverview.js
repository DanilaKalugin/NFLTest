class StatsOverview extends HTMLElement {
    render() {
        this.innerHTML = '';
        let $statName = document.createElement('div');
        $statName.innerHTML = this.getAttribute('key');
        $statName.classList.add('stat-name');
        this.appendChild($statName);

        let $statData = document.createElement('div');
        $statData.innerHTML = this.getAttribute('value');
        $statData.classList.add('stat-value');
        this.appendChild($statData);
    }

    connectedCallback() {
        if (!this.rendered) {
            this.render();
            this.rendered = true;
        }
    }

    constructor() {
        super();
    }

    attributeChangedCallback(name, oldValue, newValue) {
        this.render();
    }


    setValue (value)
    {
        let $value = this.lastChild;
        $value.innerHTML = value;
    }
}



window.customElements.define('stats-overview', StatsOverview);