import { Breadcrumb } from 'react-bootstrap';
import { faHome } from '@fortawesome/free-solid-svg-icons'
import { LinkContainer } from 'react-router-bootstrap';
import {  useHistory } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import {useAuth} from '../Auth/auth.js';


let roleUser = {
  user: 'USER',
  admin: 'ADMIN',
  superAdmin:'SUPERADMIN'
}

let roleUserVerif = {
  user: 'USER,ADMIN,SUPERADMIN',
  admin: 'ADMIN,SUPERADMIN',
  superAdmin:'SUPERADMIN'
}


let GetBreadCrumb = () => {
  const {user}=useAuth();
  let menu = window.localStorage.getItem('breadcrumb');
  if (menu == null) {
    menu = [];
  }
  else {
    menu = JSON.parse(menu);
  }
  let history = useHistory();
  let ClickItem = (item,nb) => {
    if (item.url !== "") {
      history.push(item.url)
    }
    var nMenu =[];
    for(let i=0;i<menu.length;i++){
      if(i<nb+1){
        nMenu=[...nMenu,menu[i]];
      }
    }
    window.localStorage.setItem('breadcrumb',JSON.stringify(nMenu));
  };

  return <div style={{ display:'flex', flexDirection:'row', marginTop:'1%' }}>
    <LinkContainer to={user!=null?"/Dashboard":"/"}>
      <Breadcrumb.Item>
        <FontAwesomeIcon icon={faHome} />
      </Breadcrumb.Item>
    </LinkContainer>
    {
      menu.map((item, nb) => {
        return <Breadcrumb.Item onClick={() => { if(nb !== menu.length - 1){ClickItem(item,nb);} }} active={nb === menu.length - 1} >
          {item.name}
        </Breadcrumb.Item>
      })
    }
  </div>
};

let AddToBreadCrumb = (name, url, reset, temporary) => {
  let menu = [];
  if (!reset) {
    menu = window.localStorage.getItem('breadcrumb');
    if (menu == null) {
      menu = [];
    }
    else {
      menu = JSON.parse(menu);
    }
  }
  menu = menu.filter(i => !i.temporary);
  if (menu.find(i => i.name === name) == null) {
    menu = [...menu, { name, url, temporary }];
  }
  window.localStorage.setItem('breadcrumb', JSON.stringify(menu));
};


let ResetBreadCrumb = () => {
  let menu = [];
  window.localStorage.setItem('breadcrumb', JSON.stringify(menu));
};



export { roleUser , ResetBreadCrumb, AddToBreadCrumb, GetBreadCrumb, roleUserVerif };