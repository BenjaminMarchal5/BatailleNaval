import { checkStatus, url_prefix } from './fetchUtils.js';

const eventsAPI = {
	modifyUser: (idUser,user) => {
		let token=window.localStorage.getItem('token');
		return fetch(`${url_prefix}/User/`+idUser, {
			method: 'PATCH',
			headers:{'Content-Type': 'application/json',Authorization: `Bearer ${token}`},
			body:JSON.stringify(user)
		})
			.then(checkStatus).then(res => res.json());;
	},
	signup: (user) => {
		return fetch(`${url_prefix}/User/signup`, {
			method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body:JSON.stringify(user)
		})
			.then(checkStatus);
	},
	whoami: (token) => {
		return fetch(`${url_prefix}/User/whoami`, {
			method: 'GET',
			headers: { Authorization: `Bearer ${token}` }
		})
			.then(checkStatus)
			.then(res => res.json());
	},
	signin: (user) => {
		return fetch(`${url_prefix}/User/signin`, {
			method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body:JSON.stringify(user)
		})
			.then(checkStatus).then(data=> {return data.text();});
	}
};

export {eventsAPI};