'use client';

import { useState, useEffect } from 'react';
import { NutritionLogDto } from '../../lib/types';
import apiClient from '../../lib/api/client';
import { useAuth } from '../../..../../context/AuthContext';
import NutritionLogCard from '../../components/ui/NutritionLogCard';
import NutritionModal from '../../components/forms/NutritionModal';

export default function NutritionPage() {
  const [logs, setLogs] = useState<NutritionLogDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { user } = useAuth();

  useEffect(() => {
    const fetchNutritionLogs = async () => {
      try {
        const response = await apiClient.get(`/nutrition/user/${user?.id}`);
        setLogs(response.data);
      } catch (error) {
        console.error('Failed to fetch nutrition logs', error);
      } finally {
        setLoading(false);
      }
    };

    if (user?.id) {
      fetchNutritionLogs();
    }
  }, [user?.id]);

  const handleAddLog = async (logData: NutritionLogDto) => {
    try {
      const response = await apiClient.post('/nutrition', {
        ...logData,
        userId: user?.id,
      });
      setLogs([...logs, response.data]);
      setIsModalOpen(false);
    } catch (error) {
      console.error('Failed to add nutrition log', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Nutrition Logs</h1>
        <button
          onClick={() => setIsModalOpen(true)}
          className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
        >
          Add Log
        </button>
      </div>

      {logs.length === 0 ? (
        <div className="text-center py-12">
          <p className="text-gray-500">No nutrition logs yet. Add your first log!</p>
        </div>
      ) : (
        <div className="space-y-4">
          {logs.map((log) => (
            <NutritionLogCard key={log.id} log={log} />
          ))}
        </div>
      )}

      <NutritionModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        onSubmit={handleAddLog}
      />
    </div>
  );
}