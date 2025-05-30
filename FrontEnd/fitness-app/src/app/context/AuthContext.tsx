'use client';

import { createContext, useContext, useState, ReactNode, useEffect } from 'react';
import { useRouter } from 'next/navigation';
import apiClient from '../lib/api/client';
import { User, LoginUserDto, UserRegisterDto } from '../lib/types';
interface AuthContextType {
  user: User | null;
  login: (credentials: LoginUserDto) => Promise<void>;
  register: (userData: UserRegisterDto) => Promise<void>;
  logout: () => void;
  isAuthenticated: boolean;
  loading: boolean;
}

const AuthContext = createContext<AuthContextType | undefined>(undefined);

export const AuthProvider = ({ children }: { children: ReactNode }) => {
  const [user, setUser] = useState<User | null>(null);
  const [loading, setLoading] = useState(true);
  const router = useRouter();

  useEffect(() => {
    const loadUser = async () => {
      try {
        const token = localStorage.getItem('authToken');
        if (token) {
          // You might want to add an endpoint to fetch user data
          // const response = await apiClient.get('/auth/me');
          // setUser(response.data);
        }
      } catch (error) {
        console.error('Failed to load user', error);
        localStorage.removeItem('authToken');
      } finally {
        setLoading(false);
      }
    };

    loadUser();
  }, []);

  const login = async (credentials: LoginUserDto) => {
    try {
      const response = await apiClient.post('/auth/login', credentials);
      localStorage.setItem('authToken', response.data.token);
      // setUser(response.data.user);
      router.push('/dashboard');
    } catch (error) {
      console.error('Login failed', error);
      throw error;
    }
  };

  const register = async (userData: UserRegisterDto) => {
    try {
      const response = await apiClient.post('/auth/register', userData);
      localStorage.setItem('authToken', response.data.token);
      // setUser(response.data.user);
      router.push('/dashboard');
    } catch (error) {
      console.error('Registration failed', error);
      throw error;
    }
  };

  const logout = () => {
    localStorage.removeItem('authToken');
    setUser(null);
    router.push('/login');
  };

  return (
    <AuthContext.Provider
      value={{
        user,
        login,
        register,
        logout,
        isAuthenticated: !!user,
        loading,
      }}
    >
      {children}
    </AuthContext.Provider>
  );
};

export const useAuth = () => {
  const context = useContext(AuthContext);
  if (context === undefined) {
    throw new Error('useAuth must be used within an AuthProvider');
  }
  return context;
};