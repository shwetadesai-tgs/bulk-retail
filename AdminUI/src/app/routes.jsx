import AuthGuard from 'app/auth/AuthGuard';
import dashboardRoutes from 'app/views/dashboard/DashboardRoutes';
import NotFound from 'app/views/sessions/NotFound';
import sessionRoutes from 'app/views/sessions/SessionRoutes';
import { Navigate } from 'react-router-dom';
import MatxLayout from './components/MatxLayout/MatxLayout';
import crudRoute from 'app/views/CRUD/CrudRoutes';

const routes = [
  {
    element: (
      <AuthGuard>
        <MatxLayout />
      </AuthGuard>
    ),
    children: [...dashboardRoutes, ...crudRoute],
  },
  ...sessionRoutes,
  { path: '/', element: <Navigate to="dashboard" /> },
  { path: '*', element: <NotFound /> },
];

export default routes;
