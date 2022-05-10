import './App.css';
import { QueryClient, QueryClientProvider } from 'react-query'
import { ReactQueryDevtools } from 'react-query/devtools'
import { BrowserRouter as Router} from "react-router-dom";
import { AuthProvider } from "./Auth/auth.js";
import {BattleShip} from './BattleShip';

function App() {
  const queryClient = new QueryClient();
  return (
    <div className="App">
      <QueryClientProvider client={queryClient}>
        <Router>
          <AuthProvider>
            <BattleShip />
          </AuthProvider>
        </Router>
        <ReactQueryDevtools initialIsOpen={false} />
      </QueryClientProvider>

    </div>
  );
}

export default App;
