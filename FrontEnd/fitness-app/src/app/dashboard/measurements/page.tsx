'use client';

import { useState, useEffect } from 'react';
import { MeasurementDto } from '../../lib/types';
import apiClient from '../../lib/api/client';
import { useAuth } from '../../..../../context/AuthContext';
import MeasurementCard from '../../components/ui/ExerciseCard';
import MeasurementModal from '../../components/forms/WorkoutModal';
import MeasurementsChart from '../../components/charts/MeasurementsChart';

export default function MeasurementsPage() {
  const [measurements, setMeasurements] = useState<MeasurementDto[]>([]);
  const [loading, setLoading] = useState(true);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const { user } = useAuth();

  useEffect(() => {
    const fetchMeasurements = async () => {
      try {
        const response = await apiClient.get(`/measurements/user/${user?.id}`);
        setMeasurements(response.data);
      } catch (error) {
        console.error('Failed to fetch measurements', error);
      } finally {
        setLoading(false);
      }
    };

    if (user?.id) {
      fetchMeasurements();
    }
  }, [user?.id]);

  const handleAddMeasurement = async (measurementData: MeasurementDto) => {
    try {
      const response = await apiClient.post('/measurements', {
        ...measurementData,
        userId: user?.id,
      });
      setMeasurements([...measurements, response.data]);
      setIsModalOpen(false);
    } catch (error) {
      console.error('Failed to add measurement', error);
    }
  };

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <div className="space-y-6">
      <div className="flex justify-between items-center">
        <h1 className="text-2xl font-bold">Body Measurements</h1>
        <button
          onClick={() => setIsModalOpen(true)}
          className="px-4 py-2 bg-indigo-600 text-white rounded-md hover:bg-indigo-700"
        >
          Add Measurement
        </button>
      </div>

      <MeasurementsChart measurements={measurements} />

      {measurements.length === 0 ? (
        <div className="text-center py-12">
          <p className="text-gray-500">No measurements yet. Add your first measurement!</p>
        </div>
      ) : (
        <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-6">
          {measurements.map((measurement) => (
            <MeasurementCard key={measurement.id} measurement={measurement} />
          ))}
        </div>
      )}

      <MeasurementModal
        isOpen={isModalOpen}
        onClose={() => setIsModalOpen(false)}
        onSubmit={handleAddMeasurement}
      />
    </div>
  );
}